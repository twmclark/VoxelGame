public class BlockGrass: Block
{
    public override Tile TexturePosition(Direction direction)
    {
        switch (direction)
        {
           case Direction.Up:
               return new Tile {X = 2, Y = 0};

           case Direction.Down:
               return new Tile {X = 1, Y = 0};
        }
        
        return new Tile {X = 3, Y = 0};
    }
}