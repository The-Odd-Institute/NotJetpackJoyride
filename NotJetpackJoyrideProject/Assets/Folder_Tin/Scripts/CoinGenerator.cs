using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool generateOnStart = default;
    [SerializeField] private Transform pfCoin = default;
    [SerializeField] private Transform pfCoinGroup = default;
    [SerializeField] private Transform childHolder = default;
    [SerializeField] private Texture2D[] textPattern = default;

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
                PlaceCoinBasedOnChar(textPattern[0], spawnPosition).SetParent(parent);
            else if (c == 'a' | c == 'A')
                PlaceCoinBasedOnChar(textPattern[1], spawnPosition).SetParent(parent);
            else if (c == 'b' | c == 'B')
                PlaceCoinBasedOnChar(textPattern[2], spawnPosition).SetParent(parent);
            else if (c == 'c' | c == 'C')
                PlaceCoinBasedOnChar(textPattern[3], spawnPosition).SetParent(parent);
            else if (c == 'd' | c == 'D')
                PlaceCoinBasedOnChar(textPattern[4], spawnPosition).SetParent(parent);
            else if (c == 'e' | c == 'E')
                PlaceCoinBasedOnChar(textPattern[5], spawnPosition).SetParent(parent);
            else if (c == 'f' | c == 'F')
                PlaceCoinBasedOnChar(textPattern[6], spawnPosition).SetParent(parent);
            else if (c == 'g' | c == 'G')
                PlaceCoinBasedOnChar(textPattern[7], spawnPosition).SetParent(parent);
            else if (c == 'h' | c == 'H')
                PlaceCoinBasedOnChar(textPattern[8], spawnPosition).SetParent(parent);
            else if (c == 'i' | c == 'I')
                PlaceCoinBasedOnChar(textPattern[9], spawnPosition).SetParent(parent);
            else if (c == 'j' | c == 'J')
                PlaceCoinBasedOnChar(textPattern[10], spawnPosition).SetParent(parent);
            else if (c == 'k' | c == 'K')
                PlaceCoinBasedOnChar(textPattern[11], spawnPosition).SetParent(parent);
            else if (c == 'l' | c == 'L')
                PlaceCoinBasedOnChar(textPattern[12], spawnPosition).SetParent(parent);
            else if (c == 'm' | c == 'M')
                PlaceCoinBasedOnChar(textPattern[13], spawnPosition).SetParent(parent);
            else if (c == 'n' | c == 'N')
                PlaceCoinBasedOnChar(textPattern[14], spawnPosition).SetParent(parent);
            else if (c == 'o' | c == 'O')
                PlaceCoinBasedOnChar(textPattern[15], spawnPosition).SetParent(parent);
            else if (c == 'p' | c == 'P')
                PlaceCoinBasedOnChar(textPattern[16], spawnPosition).SetParent(parent);
            else if (c == 'q' | c == 'Q')
                PlaceCoinBasedOnChar(textPattern[17], spawnPosition).SetParent(parent);
            else if (c == 'r' | c == 'R')
                PlaceCoinBasedOnChar(textPattern[18], spawnPosition).SetParent(parent);
            else if (c == 's' | c == 'S')
                PlaceCoinBasedOnChar(textPattern[19], spawnPosition).SetParent(parent);
            else if (c == 't' | c == 'T')
                PlaceCoinBasedOnChar(textPattern[20], spawnPosition).SetParent(parent);
            else if (c == 'u' | c == 'U')
                PlaceCoinBasedOnChar(textPattern[21], spawnPosition).SetParent(parent);
            else if (c == 'v' | c == 'V')
                PlaceCoinBasedOnChar(textPattern[22], spawnPosition).SetParent(parent);
            else if (c == 'w' | c == 'W')
                PlaceCoinBasedOnChar(textPattern[23], spawnPosition).SetParent(parent);
            else if (c == 'x' | c == 'X')
                PlaceCoinBasedOnChar(textPattern[24], spawnPosition).SetParent(parent);
            else if (c == 'y' | c == 'Y')
                PlaceCoinBasedOnChar(textPattern[25], spawnPosition).SetParent(parent);
            else if (c == 'z' | c == 'Z')
                PlaceCoinBasedOnChar(textPattern[26], spawnPosition).SetParent(parent);
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