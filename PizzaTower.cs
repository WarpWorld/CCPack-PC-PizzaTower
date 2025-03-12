using CrowdControl.Common;
using JetBrains.Annotations;
using AddressChain = ConnectorLib.Memory.AddressChain<ConnectorLib.Inject.InjectConnector>;
using ConnectorType = CrowdControl.Common.ConnectorType;

namespace CrowdControl.Games.Packs.PizzaTower;

// //ccpragma { "include" : [ "..\\Windows10\\SimpleOverlayManager.cs" ] }
[UsedImplicitly]
public class PizzaTower : InjectEffectPack
{
    public PizzaTower([NotNull] UserRecord player, [NotNull] Func<CrowdControlBlock, bool> responseHandler,Action<object> statusUpdateHandler) : base(player, responseHandler, statusUpdateHandler)
    {
        VersionProfiles = [new("PizzaTower", InitPizzaTower, DeinitPizzaTower)];
    }
    private AddressChain _chain_thing;
    private void InitPizzaTower()
    {
        byte[] p = [0x5f, 0x63, 0x63, 0x6d, 0x61, 0x67, 0x69, 0x63, 0x68, 0x6f, 0x6f, 0x6b];
        _chain_thing = AddressChain
            .AOB(this.Connector, 0, p, "xxxxxxxxxxxx", -255, 0, 0x017F50FF).Cache()
            .PreCache();

    }

    private void DeinitPizzaTower()
    {
    }

    public override EffectList Effects
    {
        get
        {
            //new Effect("Peppino Outfit", "outfit", ItemKind.BidWar),
            //new Effect("Blood Red", "outfit_red", ItemKind.BidWarValue, "outfit"),
            List<Effect> effects =
            [
                new("Mighty Knight", "t_0")
                {
                    Duration = 10, Category = "Peppino Effects", Price = 25,
                    Description = "Transform Peppino Spaghetti into Knight Peppino!"
                },
                new("Pizza Face", "_1")
                    { Duration = 5, Category = "Enemies", Price = 500, Description = "Wake up Pizzaface! TIMES UP!" },
                //new Effect("Turn Around", "_2"),
                new("Boxxed", "t_3")
                {
                    Duration = 10, Category = "Peppino Effects", Price = 50,
                    Description = "Transform Peppino Spaghetti into Pizza Box Peppino!"
                },
                new("Gustavo Time", "t_4")
                {
                    Duration = 15, Category = "Peppino Effects", Price = 50,
                    Description = "Transform Peppino Spaghetti into Gustavo and Brick!"
                },
                new("Wide and Fast", "a_5")
                {
                    Duration = 20, Category = "Peppino Effects", Price = 25,
                    Description =
                        "Transform Peppino Spaghetti into an extra wide version of himself. This also increases his movement speed!"
                },
                new("Slow and Thin", "a_27")
                {
                    Duration = 20, Category = "Peppino Effects", Price = 25,
                    Description =
                        "Transform Peppino Spaghetti into an extra thin version of himself. This also decreases his movement speed!"
                },
                new("Inverted Move", "_28_hold")
                {
                    Duration = 15, Category = "Game Effects", Price = 100,
                    Description = "Make this way go that way and that way go this way!"
                },
                new("GUN", "g_6")
                {
                    Duration = 30, Category = "Peppino Effects", Price = 50,
                    Description = "Grant Peppino Spaghetti a sweet shotgun!"
                },
                new("Chicken Rain", "t_7") { Category = "Enemies", Price = 25, Description = "Rain down chickens! " },
                new("Devil Pizza", "_8")
                {
                    Duration = 20, Category = "Peppino Effects", Price = 50,
                    Description = "Grant Peppino Spaghetti the effects Satan's Pepper Pizza!"
                },
                //new Effect("Pillar John", "_9"),
                new("Speed Up Game", "_10")
                {
                    Duration = 10, Category = "Game Effects", Price = 100,
                    Description = "Make the game even faster! Fast fast fast fast fast!!! GO GO GO GO GO GO!!!"
                },
                new("Hard Mode", "_11")
                {
                    Duration = 30, Category = "Enemies", Price = 150,
                    Description = "Summon the Snick.exe! He will float around the screen and drop enemies!"
                },
                new("Fire Mouth", "t_12")
                {
                    Duration = 10, Category = "Peppino Effects", Price = 25,
                    Description =
                        "Grant Peppino Spaghetti the effects Kentucky Kenny's spicy chicken wings, transforming Peppino Spaghetti into Firemouth Peppino!"
                },
                new("OHKO", "_13_hold")
                {
                    Duration = 10, Category = "Peppino Effects", Price = 250,
                    Description = "The next hit on Peppino Spaghetti instantly kills him!"
                }, //hold it
                new("Mirror Mode", "_14_hold")
                    { Duration = 15, Category = "Screen Effects", Price = 100, Description = "Flip the world around!" },
                new("Upside Down Screen", "b_15_hold")
                {
                    Duration = 15, Category = "Screen Effects", Price = 100, Description = "Flip the world upside down!"
                },
                new("Sideways Screen", "b_26_hold")
                {
                    Duration = 15, Category = "Screen Effects", Price = 100, Description = "Flip the world on its side!"
                },
                new("Be Quiet", "_16")
                {
                    Category = "Enemies", Price = 250,
                    Description = "Spawns a group of Patrollers! If they count down to 0, its Tomato Monster time!"
                },
                new("Turn on a Dime", "_17_hold")
                {
                    Duration = 10, Category = "Peppino Effects", Price = 25,
                    Description = "Allows Peppino Spaghetti to instantly turn while dashing!"
                }, // hold it
                new("Goblin Air Strike", "_18")
                {
                    Category = "Enemies", Price = 150,
                    Description =
                        "Summon Captain Pizza Goblin, who shoots cannonballs! Peppino Spaghetti needs to change screens for The Captain to go away!"
                },
                new("Secret Time", "s_19")
                {
                    Category = "Game Effects", Price = 500,
                    Description =
                        "Summon a Secret Eye that will instantly swallow and teleport Peppino Spaghetti to a secret room!"
                },
                new("Hide Tiles", "_20")
                {
                    Duration = 15, Category = "Screen Effects", Price = 150, Description = "Make the tiles  disappear!"
                },
                new("Electric Trail", "_21_hold")
                {
                    Duration = 10, Category = "Enemies", Price = 150,
                    Description =
                        "A string of electric outlets follow Peppino Spaghetti. This will cause damage and maybe even block exits!"
                }, //hold it
                new("Add Lap", "_22") { Category = "Laps", Price = 350, Description = "Add a lap!" },
                new("Add Lap Deluxe", "_23") { Category = "Laps", Price = 500, Description = "???" },
                new("Elite Enemies", "_24_hold")
                {
                    Duration = 30, Category = "Enemies", Price = 150,
                    Description =
                        "Temporarily make enemies stronger! Meaning they take more damage to kill and may not be easily grabbed!"
                }
                //new Effect("Reset (test)", "_25"),
            ];
            return effects;
        }
    }

    public override Game Game { get; } = new("PizzaTower", "PizzaTower", "PC", ConnectorType.PCConnector);

    protected override GameState GetGameState()
    {
        string x;
        try
        {
            string queueFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\PizzaTower_GM2\\ccout.txt";
            x = File.ReadAllText(queueFile);
        }
        catch { return GameState.Unknown; }
        if (x.Contains("noruneffect")) return GameState.PipelineBusy;
        return GameState.Ready;
    }

    protected override bool IsReady(EffectRequest? request)
    {
        string x;
        try
        {
            string queueFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\PizzaTower_GM2\\ccout.txt";
            x = File.ReadAllText(queueFile);
        }
        catch { return false; }
        if (x.Contains("noruneffect")) return false;
        if (request.EffectID[0] == 's' && x.Contains("insecret")) return false;
        if (request.EffectID[0] == 'g' && x.Contains("nogun")) return false;
        return true;
    }
    
    protected override void StartEffect(EffectRequest request)
    {
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
        }
    }

    protected override bool StopEffect(EffectRequest request)
    {
        //bad but whatever - kat
        try
        {
            string[] codeParams = request.EffectID.Split('_');
            _chain_thing.Offset(byte.Parse(codeParams[1])).SetByte(95);
            return true;
        }
        catch { return base.StopEffect(request); }
    }

    public override bool StopAllEffects()
    {
        bool result = base.StopAllEffects();
        return result;
    }
}