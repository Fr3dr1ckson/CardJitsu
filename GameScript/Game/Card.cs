using GameScript.Useful_Functions;

namespace GameScript.Game;

public class Card
{
    enum Abilities
    {
        None,
        BlockFire,
        BlockSnow,
        BlockWater,
        PowerPlus,
        PowerMinus,
        TheLowestWins,
        DestroyFire,
        DestroyWater,
        DestroySnow
    }

    public static int AbilitiesLength()
    {
        return Enum.GetNames(typeof(Abilities)).Length;
    }
    public static readonly string[] ElementList =
    {
        "Fire", "Water", "Snow"
    };
    
    public string? Element { get;}
    public Lenny? Lenny { get;}
    public int? Power{ get;}

    Abilities Ability = Abilities.None;
    public Card(int power, string element, string lenny, int abilityID = 0)
    {
        Power = power;
        Element = element;
        Lenny.value = lenny;
        Lenny.element = element;
    }

    public Card(int abilityID)
    {
        Ability = abilityID switch
        {
            1 => Abilities.DestroySnow,
            2 => Abilities.BlockFire,
            3 => Abilities.PowerMinus,
            4 => Abilities.TheLowestWins,
            5 => Abilities.PowerMinus,
            _ => Ability
        };
    }
    private static List<Card> GenerateLib()
    {
        List<Card> deck = new List<Card>();
        string[] elementList = ElementList;
        foreach (string element in elementList)
        {
            foreach (string lenny in Lenny.Faces)
            {
                for (int power = 1; power < 11; power++)
                {
                    deck.Add(new Card(power, element, lenny));
                }
            }
        }
        return deck;
    }

    public static readonly List<Card> CardLib = GenerateLib();
}

