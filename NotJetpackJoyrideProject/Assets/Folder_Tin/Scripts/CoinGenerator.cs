using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool generateOnStart = default;
    [SerializeField] private Transform pfCoin = default;
    [SerializeField] private Transform pfCoinGroup = default;
    [SerializeField] private Transform childHolder = default;
    [SerializeField] private Texture2D[] alphabetPatterns = default;

    [Header("Generate Configs")]
    [SerializeField] private bool generateText = default;
    [SerializeField] private float textWeigth = default;
    [SerializeField] private string[] coinText = default;
    [Space]
    [SerializeField] private bool generatePattern = default;
    [SerializeField] private float patternWeigth = default;
    [SerializeField] private Texture2D[] coinPatterns = default;

    private const float OFFSET_UNIT = 1.0f;
    Vector2 spawnPosition = Vector2.zero;
    private float textRatioWeigth = default;

    private void Start()
    {
        // Compute weight
        textRatioWeigth = textWeigth / (textWeigth + patternWeigth);

        if (generateOnStart == false)
            return;

        GenerateRandom();
    }

    private Transform PlaceCoin(Texture2D pattern, Vector2 position)
    {
        // Get bitmap
        Color[] pix = pattern.GetPixels(); // bottom left, left->right => bottom->top

        int patternX = pattern.width;
        int patternY = pattern.height;

        Vector2[] spawnPositions = new Vector2[pix.Length];
        Vector2 startPosition = position;
        Vector2 currentPosition = startPosition;

        int i = default;
        for (int y = 0; y < patternY; y++)
        {
            for (int x = 0; x < patternX; x++)
            {
                spawnPositions[i] = currentPosition;
                i++;
                currentPosition.x += OFFSET_UNIT;
            }

            currentPosition.x = startPosition.x;
            currentPosition.y += OFFSET_UNIT;
        }

        i = 0;

        // Instantiate holder transform
        Transform holder = Instantiate(childHolder, Vector3.zero, Quaternion.identity);

        // Instantiate coins
        foreach (Vector3 pos in spawnPositions)
        {
            Color c = pix[i];
            if (c.Equals(Color.black))
                Instantiate(pfCoin, pos, Quaternion.identity, holder);

            i++;
        }

        return holder;
    }

    private Transform PlaceCoinBasedOnChar(Texture2D pattern, Vector2 position)
    {
        Transform group = PlaceCoin(pattern, position);
        spawnPosition.x += OFFSET_UNIT * pattern.width + OFFSET_UNIT;

        return group;
    }

    //======================================================================
    public Transform GenerateRandom()
    {
        // ZOMBIES
        if (generatePattern == false && generateText)
            GenerateText();
        else if (generateText == false && generatePattern)
            GeneratePattern();

        float f = Random.value;
        if (f <= textRatioWeigth)
            return GenerateText();
        else
            return GeneratePattern();
    }

    public Transform GenerateText()
    {
        if (generateText == false)
            return null;

        // Get random text
        string text = coinText[Random.Range(0, coinText.Length)];

        // Instantiate parent transform
        Transform parent = Instantiate(pfCoinGroup, Vector3.zero, Quaternion.identity);

        spawnPosition = Vector2.zero;
        foreach (char c in text)
        {
            if (c == ' ')
                spawnPosition.x += OFFSET_UNIT;
            else if (c == '!')
                PlaceCoinBasedOnChar(alphabetPatterns[0], spawnPosition).SetParent(parent);
            else if (c == 'a' | c == 'A')
                PlaceCoinBasedOnChar(alphabetPatterns[1], spawnPosition).SetParent(parent);
            else if (c == 'b' | c == 'B')
                PlaceCoinBasedOnChar(alphabetPatterns[2], spawnPosition).SetParent(parent);
            else if (c == 'c' | c == 'C')
                PlaceCoinBasedOnChar(alphabetPatterns[3], spawnPosition).SetParent(parent);
            else if (c == 'd' | c == 'D')
                PlaceCoinBasedOnChar(alphabetPatterns[4], spawnPosition).SetParent(parent);
            else if (c == 'e' | c == 'E')
                PlaceCoinBasedOnChar(alphabetPatterns[5], spawnPosition).SetParent(parent);
            else if (c == 'f' | c == 'F')
                PlaceCoinBasedOnChar(alphabetPatterns[6], spawnPosition).SetParent(parent);
            else if (c == 'g' | c == 'G')
                PlaceCoinBasedOnChar(alphabetPatterns[7], spawnPosition).SetParent(parent);
            else if (c == 'h' | c == 'H')
                PlaceCoinBasedOnChar(alphabetPatterns[8], spawnPosition).SetParent(parent);
            else if (c == 'i' | c == 'I')
                PlaceCoinBasedOnChar(alphabetPatterns[9], spawnPosition).SetParent(parent);
            else if (c == 'j' | c == 'J')
                PlaceCoinBasedOnChar(alphabetPatterns[10], spawnPosition).SetParent(parent);
            else if (c == 'k' | c == 'K')
                PlaceCoinBasedOnChar(alphabetPatterns[11], spawnPosition).SetParent(parent);
            else if (c == 'l' | c == 'L')
                PlaceCoinBasedOnChar(alphabetPatterns[12], spawnPosition).SetParent(parent);
            else if (c == 'm' | c == 'M')
                PlaceCoinBasedOnChar(alphabetPatterns[13], spawnPosition).SetParent(parent);
            else if (c == 'n' | c == 'N')
                PlaceCoinBasedOnChar(alphabetPatterns[14], spawnPosition).SetParent(parent);
            else if (c == 'o' | c == 'O')
                PlaceCoinBasedOnChar(alphabetPatterns[15], spawnPosition).SetParent(parent);
            else if (c == 'p' | c == 'P')
                PlaceCoinBasedOnChar(alphabetPatterns[16], spawnPosition).SetParent(parent);
            else if (c == 'q' | c == 'Q')
                PlaceCoinBasedOnChar(alphabetPatterns[17], spawnPosition).SetParent(parent);
            else if (c == 'r' | c == 'R')
                PlaceCoinBasedOnChar(alphabetPatterns[18], spawnPosition).SetParent(parent);
            else if (c == 's' | c == 'S')
                PlaceCoinBasedOnChar(alphabetPatterns[19], spawnPosition).SetParent(parent);
            else if (c == 't' | c == 'T')
                PlaceCoinBasedOnChar(alphabetPatterns[20], spawnPosition).SetParent(parent);
            else if (c == 'u' | c == 'U')
                PlaceCoinBasedOnChar(alphabetPatterns[21], spawnPosition).SetParent(parent);
            else if (c == 'v' | c == 'V')
                PlaceCoinBasedOnChar(alphabetPatterns[22], spawnPosition).SetParent(parent);
            else if (c == 'w' | c == 'W')
                PlaceCoinBasedOnChar(alphabetPatterns[23], spawnPosition).SetParent(parent);
            else if (c == 'x' | c == 'X')
                PlaceCoinBasedOnChar(alphabetPatterns[24], spawnPosition).SetParent(parent);
            else if (c == 'y' | c == 'Y')
                PlaceCoinBasedOnChar(alphabetPatterns[25], spawnPosition).SetParent(parent);
            else if (c == 'z' | c == 'Z')
                PlaceCoinBasedOnChar(alphabetPatterns[26], spawnPosition).SetParent(parent);
        }

        return parent;
    }

    public Transform GeneratePattern()
    {
        if (generatePattern == false)
            return null;

        // Get random pattern
        Texture2D pattern = coinPatterns[Random.Range(0, coinPatterns.Length)];

        return PlaceCoin(pattern, Vector2.zero);
    }
}