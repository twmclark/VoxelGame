public struct WorldPosition
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public WorldPosition(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public override bool Equals(object obj)
    {
        if (!(obj is WorldPosition))
            return false;
 
        WorldPosition pos = (WorldPosition)obj;
        return pos.X == X && pos.Y == Y && pos.Z == Z;
    }
}