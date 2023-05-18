using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using AsmJit.Common.Operands;
using ConnectorLib;
using ConnectorLib.Inject;
using ConnectorLib.Inject.AddressChaining;
using ConnectorLib.Inject.CSharpExtensions;
using ConnectorLib.Inject.Payload.DirectX;
using ConnectorLib.Inject.VersionProfiles;
using ConnectorLib.Inject.VersionProfiles.Verification;
using CrowdControl.Common;
using JetBrains.Annotations;
using System.Runtime.InteropServices;
using ConnectorType = CrowdControl.Common.ConnectorType;

namespace CrowdControl.Games.Packs
{

    // //ccpragma { "include" : [ "..\\Windows10\\SimpleOverlayManager.cs" ] }
    [UsedImplicitly]
    public class PizzaTower : InjectEffectPack
    {
        public PizzaTower([NotNull] UserRecord player, [NotNull] Func<CrowdControlBlock, bool> responseHandler,Action<object> statusUpdateHandler) : base(player, responseHandler, statusUpdateHandler)
        {
            VersionProfiles = new List<VersionProfile> { new VersionProfile("PizzaTower", InitCrashBandicootNSaneTrilogy, DeinitCrashBandicootNSaneTrilogy, null, Direct3DVersion.None), };
        }
        private AddressChain _chain_thing;
        private void InitCrashBandicootNSaneTrilogy()
        {
            byte[] p = { 0x5f, 0x63, 0x63, 0x6d, 0x61, 0x67, 0x69, 0x63, 0x68, 0x6f, 0x6f, 0x6b };
            _chain_thing = AddressChain
                .AOB(this.Connector, 0, p, "xxxxxxxxxxxx", -255, 0, 0x017F50FF).Cache()
                .PreCache();

        }

        private void DeinitCrashBandicootNSaneTrilogy()
        {
        }

        public override EffectList Effects
        {
            get
            {
                //new Effect("Peppino Outfit", "outfit", ItemKind.BidWar),
                //new Effect("Blood Red", "outfit_red", ItemKind.BidWarValue, "outfit"),
                List<Effect> effects = new List<Effect>{
                new Effect("Mighty Knight", "t_0"){Duration=10},
                new Effect("Pizza Face", "_1"){Duration=5},
                //new Effect("Turn Around", "_2"),
                new Effect("Boxxed", "t_3"){Duration=10},
                new Effect("Gustavo Time", "t_4"){Duration=15},
                new Effect("Wide and Fast", "a_5"){Duration=20},
                new Effect("Slow and Thin", "a_27"){Duration=20},
                new Effect("Inverted Move", "_28_hold"){Duration=15},
                new Effect("GUN", "g_6"){Duration=30},
                new Effect("Chicken Rain", "t_7"),
                new Effect("Devil Pizza", "_8"){Duration=20},
                //new Effect("Pillar John", "_9"),
                new Effect("Speed Up Game", "_10"){Duration=10},
                new Effect("Hard Mode", "_11"){Duration=30},
                new Effect("Fire Mouth", "t_12"){Duration=10},
                new Effect("OHKO", "_13_hold"){Duration=10}, //hold it
                new Effect("Mirror Mode", "_14_hold"){Duration=15},
                new Effect("Upside Down Screen", "b_15_hold"){Duration=15},
                new Effect("Sideways Screen", "b_26_hold"){Duration=15},
                new Effect("Be Quiet", "_16"),
                new Effect("Turn on a Dime", "_17_hold"){Duration=10}, // hold it
                new Effect("Goblin Air Strike", "_18"),
                new Effect("Secret Time", "s_19"),
                new Effect("Hide Tiles", "_20"){Duration=15},
                new Effect("Electric Trail", "_21_hold"){Duration=10}, //hold it
                new Effect("Add Lap", "_22"),
                new Effect("Add Lap Deluxe", "_23"),
                new Effect("Elite Enemies", "_24_hold"){Duration=30},
               // new Effect("Reset (test)", "_25"),
                        };
                return effects;
            }
        }

        public override Game Game => new Game(139, "PizzaTower", "PizzaTower", "PC", ConnectorType.PCConnector);
        protected override bool IsReady(EffectRequest request)
        {
            string joe = "C:\\Users\\mrbro\\AppData\\Roaming\\PizzaTower_GM2\\ccout.txt";
            string x = System.IO.File.ReadAllText(joe);
            if (x.Contains("noruneffect")) return false;
            if (request.EffectID[0] == 's' && x.Contains("insecret")) return false;
            if (request.EffectID[0] == 'g' && x.Contains("nogun")) return false;
            return true;
        }
        //protected override void RequestData(DataRequest request) => Respond(request, request.Key, null, false, $"Variable name \"{request.Key}\" not known");
        protected override void StartEffect(EffectRequest request)
        {
            if (!IsReady(request))
            {
                DelayEffect(request, TimeSpan.FromSeconds(5));
                return;
            }
            string[] codeParams = request.EffectID.Split('_');
            string s = request.EffectID;
            if (codeParams[0].Length > 0) s = codeParams[0];
            if (request.Duration <= 1) request.Duration = 1;
            if (request.Duration > 0 || true)
            {
                StartTimed(request, () => true, () =>
                {
                    if (codeParams.Length == 3)
                    {
                        _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(72);
                    }
                    else
                        _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(48);
                    return true;
                }, s);
            } /*else
            {
                TryEffect(request, () => true, () =>
                {
                    if (_chain_thing.Offset(byte.Parse(codeParams[1])).GetByte() != 95)
                    {
                        _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(95);
                        return false;
                    }
                    _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(48);
                    return true;
                });
            }*/
        }

        protected override bool StopEffect(EffectRequest request)
        {
            if (!base.StopEffect(request))
                return false;
            if (!IsReady(request))
            {
                DelayEffect(request, TimeSpan.FromSeconds(5));
                return false;
            }
            string[] codeParams = request.EffectID.Split('_');
            _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(95);
            return true;
        }

        public override bool StopAllEffects()
        {
            bool result = base.StopAllEffects();
            return result;
        }
    }
}