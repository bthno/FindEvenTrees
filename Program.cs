static List<List<int>> buildGraph(int t_nodes, int t_edges, List<int> t_from, List<int> t_to)
{
    List<List<int>> graph = new List<List<int>>();

    for (int i = 0; i < t_nodes; i++)
    {
        graph.Add(new List<int>());
    }


    for (int i = 0; i < t_from.Count; i++)
    {
        graph[t_from[i]-1].Add(t_to[i]-1);
        graph[t_to[i]-1].Add(t_from[i]-1);
    }


    return graph;
}

static int evenForest(int t_nodes, int t_edges, List<int> t_from, List<int> t_to)
{
    List<bool> isNodeChecked = new List<bool>();
    for (int i = 0; i < t_nodes; i++)
    {
        isNodeChecked.Add(false);
    }
    List<int> nodeCount = new List<int>();
    for (int i = 0; i < t_nodes; i++)
    {
        nodeCount.Add(0);
    }

    List<List<int>> graph = buildGraph(t_nodes, t_edges, t_from, t_to);

    return DFS(graph, 0, nodeCount, isNodeChecked);
}

static int DFS(List<List<int>> graph, int current, List<int> nodeCount, List<bool> isNodeChecked)
{
    int countOfEdgesCut = 0;

    if (isNodeChecked[current])
        return 0;

    isNodeChecked[current] = true;
    nodeCount[current] = 1;

    foreach (var child in graph[current])
    {
        if (!isNodeChecked[child]) {
            countOfEdgesCut += DFS(graph, child, nodeCount, isNodeChecked);
            nodeCount[current] += nodeCount[child];
            if ((nodeCount[child])%2 == 0)
                countOfEdgesCut += 1;
        }
    }

    return countOfEdgesCut;
}


Console.WriteLine("Hello, World!");

/////// CASE 1 ///////

int tNodes = 10;
int tEdges = 9;
List<int> tFrom = new List<int>() { 2,3,4,5,6,7,8,9,10 };
List<int> tTo = new List<int>() { 1,1,3,2,1,2,6,8,8 };

int res = evenForest(tNodes, tEdges, tFrom, tTo);
Console.WriteLine("Case 1 result: " + res.ToString());


/////// CASE 2 ///////

tNodes = 10;
tEdges = 9;
tFrom = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
tTo = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1 };

res = evenForest(tNodes, tEdges, tFrom, tTo);
Console.WriteLine("Case 2 result: " + res.ToString());


/////// CASE 3 ///////

tNodes = 10;
tEdges = 9;
tFrom = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
tTo = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

res = evenForest(tNodes, tEdges, tFrom, tTo);
Console.WriteLine("Case 3 result: " + res.ToString());
