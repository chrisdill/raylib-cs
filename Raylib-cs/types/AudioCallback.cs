using System;

namespace Raylib_cs;

/// <summary>
/// Audio stream processor.
/// Used with Raylib.AttachAudioMixedProcessor()
/// and Raylib.DetachAudioMixedProcessor()
/// </summary>
public delegate void AudioCallback<T>(Span<T> buffer);
