﻿using System.Collections.Generic;
using System.Linq;
using YoutubeExplode.Videos.ClosedCaptions;

namespace YoutubeDownloader.Core.Downloading;

public partial record SubtitleDownloadOption(ClosedCaptionTrackInfo TrackInfo)
{
    public string Label => TrackInfo.IsAutoGenerated
        ? $"{TrackInfo.Language.Name} (auto-generated)"
        : $"{TrackInfo.Language.Name}";
}

public partial record SubtitleDownloadOption
{
    internal static IReadOnlyList<SubtitleDownloadOption> ResolveAll(ClosedCaptionManifest manifest) => manifest.Tracks
        .Select(t => new SubtitleDownloadOption(t))
        .ToArray();
}