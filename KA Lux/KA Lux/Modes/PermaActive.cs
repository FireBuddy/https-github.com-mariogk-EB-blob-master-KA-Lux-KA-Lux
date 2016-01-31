﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KA_Lux.DMGHandler;
using Settings = KA_Lux.Config.Modes.Misc;

namespace KA_Lux.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public static bool CastedE;
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (CastedE)
            {
                if (E.IsReady())
                {
                    E.Cast(Player.Instance);
                }
                else
                {
                    CastedE = false;
                }
            }

            if (R.IsReady() && Settings.KillStealR && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (targetR != null && !targetR.IsZombie && !targetR.HasUndyingBuff())
                {
                    if (targetR.Health <= SpellDamage.GetRealDamage(SpellSlot.R, targetR) &&
                        !targetR.IsInAutoAttackRange(Player.Instance) && targetR.Health > 80)
                    {
                        if (targetR.HasBuffOfType(BuffType.Snare) || targetR.HasBuffOfType(BuffType.Stun))
                        {
                            R.Cast(targetR.Position);
                        }
                        else if (targetR.HasBuffOfType(BuffType.Slow))
                        {
                            R.Cast(R.GetPrediction(targetR).CastPosition);
                        }
                        else
                        {
                            R.Cast(Prediction.Position.PredictUnitPosition(targetR, 500).To3D());
                        }
                    }
                }
            }

            if (W.IsReady() && Settings.WDefense && Player.Instance.Mana >= Settings.WMana)
            {
                if (Player.Instance.InDanger(80))
                {
                    W.Cast(Player.Instance);
                }
            }
            
            if (Q.IsReady() && Settings.KillStealQ && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetQ = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (targetQ != null && !targetQ.IsZombie && !targetQ.HasUndyingBuff())
                {

                    if (Prediction.Health.GetPrediction(targetQ, Q.CastDelay) <= SpellDamage.GetRealDamage(SpellSlot.Q, targetQ) &&
                        !targetQ.IsInAutoAttackRange(Player.Instance) && targetQ.Health > 80)
                    {
                        Q.Cast(Q.GetPrediction(targetQ).CastPosition);
                    }
                }
            }
            
            if (E.IsReady() && Settings.KillStealE && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetE = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (targetE != null && !targetE.IsZombie && !targetE.HasUndyingBuff())
                {
                    if (Prediction.Health.GetPrediction(targetE, E.CastDelay) <= SpellDamage.GetRealDamage(SpellSlot.E, targetE) &&
                        !targetE.IsInAutoAttackRange(Player.Instance) && targetE.Health > 80)
                    {
                        E.Cast(E.GetPrediction(targetE).CastPosition);
                    }
                }
            }

            if (R.IsReady() && Settings.JungleSteal)
            {
                if (Settings.JungleStealBlue)
                {
                    var blue =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters()
                            .FirstOrDefault(
                                m =>
                                    Prediction.Health.GetPrediction(m, R.CastDelay) < SpellDamage.GetRealDamage(SpellSlot.R, m) + 90 &&
                                    m.IsValidTarget(R.Range) &&
                                    m.BaseSkinName == "SRU_Blue" && !m.IsInRange(Player.Instance, 1200) && m.Health > 100);
                    if (blue != null)
                    {
                        R.Cast(blue);
                    }
                }

                if (Settings.JungleStealRed)
                {
                    var red =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters()
                            .FirstOrDefault(
                                m =>
                                    Prediction.Health.GetPrediction(m, R.CastDelay) < SpellDamage.GetRealDamage(SpellSlot.R, m) + 90 &&
                                    m.IsValidTarget(R.Range) &&
                                    m.BaseSkinName == "SRU_Red" && !m.IsInRange(Player.Instance, 1200) && m.Health > 100);
                    if (red != null)
                    {
                        R.Cast(red);
                    }
                }

                if (Settings.JungleStealDrag)
                {
                    var drag =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters()
                            .FirstOrDefault(
                                m =>
                                    Prediction.Health.GetPrediction(m, R.CastDelay) < SpellDamage.GetRealDamage(SpellSlot.R, m) + 180 &&
                                    m.IsValidTarget(R.Range) &&
                                    m.BaseSkinName == "SRU_Dragon" && !m.IsInRange(Player.Instance, 1200) &&
                                    m.Health > 80);

                    if (drag != null)
                    {
                        R.Cast(drag);
                    }
                }

                if (Settings.JungleStealBaron)
                {
                    var baron =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters()
                            .FirstOrDefault(
                                m =>
                                    Prediction.Health.GetPrediction(m, R.CastDelay) < SpellDamage.GetRealDamage(SpellSlot.R, m) + 180 &&
                                    m.IsValidTarget(R.Range) &&
                                    m.BaseSkinName == "SRU_Baron" && !m.IsInRange(Player.Instance, 1200) &&
                                    m.Health > 80);

                    if (baron != null)
                    {
                        R.Cast(baron);
                    }
                }
            }
        }
    }
}
