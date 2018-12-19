
//一种物品的属性
struct ItemType{
    string name;
    string type;
    int id;
    int maxNum;
    int width;
    int height;
    TBlackBoard blackBoard;
}

//一种容器的属性
struct ContainerType
{
    string name;
    int id;
    int capacityX;
    int capacityY;
    TBlackBoard blackBoard;
}

//物品格
class ItemGrid{
    public Item item;
}

//物品数据
class Item
{
    public int id;
    public int num;
}

//容器数据
class Container
{
    public int id;
    public ItemGrid[][] girds;
}
