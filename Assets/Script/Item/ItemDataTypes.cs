

struct ItemType{
    string name;
    int id;
    int maxNum;
    int width;
    int height;
}

struct Item
{
    int id;
    int num;
}

struct ItemGrid
{
    Item item;
}

struct ContainerType
{
    string name;
    int id;
    int capacityX;
    int capacityY;
}

struct Container
{
    int id;
    ItemGrid[][] girds;
}
