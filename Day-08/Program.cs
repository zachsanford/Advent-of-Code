string[] rawData = File.ReadAllLines(@"Data.txt");
List<int[]> tempStructure = new();
int topVisibleDistance = 0;

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
                int resultTotal = 0;
                resultTotal += IsVisibleTop(i, j);
                resultTotal *= IsVisibleRight(i, j);
                resultTotal *= IsVisibleBottom(i, j);
                resultTotal *= IsVisibleLeft(i, j);

                if (resultTotal > topVisibleDistance)
                {
                    topVisibleDistance = resultTotal;
                }
            }
        }
    }
}

Console.WriteLine(topVisibleDistance);

#endregion

#region Methods

int IsVisibleLeft(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    int _visibility = 0;

    for (int i = _posCol - 1; i >= 0; i--)
    {
        _visibility++;
        if (_currentPos <= dataStructure[_posRow][i])
        {
            break;
        }
    }

    return _visibility;
}

int IsVisibleRight(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    int _visibility = 0;

    for (int i = _posCol + 1; i <= dataStructure[_posRow].Length - 1; i++)
    {
        _visibility++;
        if (_currentPos <= dataStructure[_posRow][i])
        {
            break;
        }
    }

    return _visibility;
}

int IsVisibleTop(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    int _visibility = 0;

    for (int i = _posRow - 1; i >= 0; i--)
    {
        _visibility++;
        if (_currentPos <= dataStructure[i][_posCol])
        {
            break;
        }
    }

    return _visibility;
}

int IsVisibleBottom(int _posRow, int _posCol)
{
    int _currentPos = dataStructure[_posRow][_posCol];
    int _visibility = 0;

    for (int i = _posRow + 1; i <= dataStructure.Length - 1; i++)
    {
        _visibility++;
        if (_currentPos <= dataStructure[i][_posCol])
        {
            break;
        }
    }

    return _visibility;
}

#endregion