﻿// Released under The Unlicense.
// See LICENSE file in the project root for full license information.
// License information can also be found at https://unlicense.org/.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Aristurtle.ParticleEngine.Data;

public struct ParticleFloatParameter : IEquatable<ParticleFloatParameter>
{
    public float Static;
    public float RandomMin;
    public float RandomMax;
    public ParticleValueKind Kind;

    public float Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (Kind == ParticleValueKind.Static)
            {
                return Static;
            }

            return FastRandom.NextSingle(RandomMin, RandomMax);
        }
    }

    public ParticleFloatParameter(float value)
    {
        Kind = ParticleValueKind.Static;
        Static = value;
        RandomMin = default;
        RandomMax = default;
    }

    public ParticleFloatParameter(float rangeStart, float rangeEnd)
    {
        Kind = ParticleValueKind.Random;
        Static = default;
        RandomMin = rangeStart;
        RandomMax = rangeEnd;
    }

    public override readonly bool Equals([NotNullWhen(true)] object? obj) => obj is ParticleFloatParameter other && Equals(other);

    public readonly bool Equals(ParticleFloatParameter other)
    {
        if (Kind == ParticleValueKind.Static)
        {
            return Static.Equals(other.Static);
        }

        return RandomMin.Equals(other.RandomMin) && RandomMax.Equals(other.RandomMax);
    }

    public override readonly int GetHashCode()
    {
        if (Kind == ParticleValueKind.Static)
        {
            return Static.GetHashCode();
        }

        return HashCode.Combine(RandomMin, RandomMax);
    }

    public override readonly string ToString()
    {
        if (Kind == ParticleValueKind.Static)
        {
            return Static.ToString(CultureInfo.InvariantCulture);
        }

        return string.Format(NumberFormatInfo.InvariantInfo, "{0}{1}{2}", RandomMin, NumberFormatInfo.InvariantInfo.NumberGroupSeparator, RandomMax);
    }

    public static bool operator ==(ParticleFloatParameter a, ParticleFloatParameter b) => a.Equals(b);

    public static bool operator !=(ParticleFloatParameter a, ParticleFloatParameter b) => !a.Equals(b);
}
