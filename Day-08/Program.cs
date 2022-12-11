string[] rawData = File.ReadAllLines(@"Data.txt");
List<int[]> tempStructure = new();
int totalVisible = 392; // Starting with the outer perimeter

foreach (string rD in rawData)
{
    List<int> tempEntry = new();
    foreach (char _rd in rD)
    {
        tempEntry.Add(Convert.ToInt32(_rd.ToString()));
    }
    tempStructure.Add(tempEntry.ToArray());
}

// dataStructure[ROW][COLUMN]
int[][] dataStructure = tempStructure.ToArray();
tempStructure.Clear();

#region Main

for (int i = 0; i < dataStructure.Length; i++)
{
    if (i != 0 || i != dataStructure.Length - 1)
    {
        for (int j = 0; j < dataStructure[i].Length; j++)
        {
            if (j != 0 || j != dataStructure[i].Length - 1)
            {
                List<bool> results = new();
                results.Add(IsVisibleTop(i, j));
                results.Add(IsVisibleRight(i, j));
                results.Add(IsVisibleBottom(i, j));
                results.Add(IsVisibleLeft(i, j));

                if (results.Any(value => value == true))
                {
                    totalVisible++;
                }
            }
        }
    }
}

Console.WriteLine(totalVisible);

#endregion

#region Methods

bool IsVisibleLeft(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    bool _isVisible = true;

    for (int i = _posCol - 1; i >= 0; i--)
    {
        if (_currentPos <= dataStructure[_posRow][i])
        {
            _isVisible = false;
            break;
        }
    }

    return _isVisible;
}

bool IsVisibleRight(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    bool _isVisible = true;

    for (int i = _posCol + 1; i <= dataStructure[_posRow].Length - 1; i++)
    {
        if (_currentPos <= dataStructure[_posRow][i])
        {
            _isVisible = false;
            break;
        }
    }

    return _isVisible;
}

bool IsVisibleTop(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    bool _isVisible = true;

    for (int i = _posRow - 1; i >= 0; i--)
    {
        if (_currentPos <= dataStructure[i][_posCol])
        {
            _isVisible = false;
            break;
        }
    }

    return _isVisible;
}

bool IsVisibleBottom(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    bool _isVisible = true;

    for (int i = _posRow + 1; i <= dataStructure.Length - 1; i++)
    {
        if (_currentPos <= dataStructure[i][_posCol])
        {
            _isVisible = false;
            break;
        }
    }

    return _isVisible;
}

#endregion