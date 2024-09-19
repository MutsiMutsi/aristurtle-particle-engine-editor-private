﻿// Released under The Unlicense.
// See LICENSE file in the project root for full license information.
// License information can also be found at https://unlicense.org/.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Aristurtle.ParticleEngine.Data;
using Aristurtle.ParticleEngine.Modifiers;
using Aristurtle.ParticleEngine.Modifiers.Containers;
using Aristurtle.ParticleEngine.Profiles;

namespace Aristurtle.ParticleEngine.MonoGame.Sample.ParticleEffects;

public sealed class RingParticleEffect : ParticleEffect
{
    public RingParticleEffect() : base(nameof(ParticleEffect))
    {
        Emitters = new List<ParticleEmitter>()
        {
            new ParticleEmitter(2000)
            {
                AutoTrigger = false,
                LifeSpan = 3.0f,
                Profile = Profile.Spray(Vector2.UnitY, 0.5f),
                Parameters = new ParticleReleaseParameters()
                {
                    Opacity = new ParticleFloatParameter(1.0f),
                    Quantity = new ParticleInt32Parameter(1),
                    Speed = new ParticleFloatParameter(300.0f, 700.0f),
                    Scale = new ParticleFloatParameter(1.0f),
                    Mass = new ParticleFloatParameter(4.0f, 12.0f),
                    Color = new ParticleColorParameter(new Vector3(210.0f, 0.5f, 0.6f), new Vector3(230.0f, 0.7f, 0.8f))
                },
                ReclaimFrequency = 5.0f,
                TextureName = "Ring001",
                Modifiers = new List<Modifiers.Modifier>()
                {
                    new LinearGravityModifier()
                    {
                        Direction = -Vector2.UnitY,
                        Strength = 100.0f,
                        Frequency = 20.0f
                    },
                    new OpacityFastFadeModifier()
                    {
                        Frequency = 10.0f
                    },
                    new ContainerModifier()
                    {
                        Frequency = 15.0f,
                        Width = 1280 * 2,
                        Height = 720 * 2,
                        RestitutionCoefficient = 0.75f,
                        Position = new Vector2(1280, 720) * 0.5f
                    }
                }
            }
        };
    }
}
