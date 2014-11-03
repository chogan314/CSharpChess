namespace CSharpChess
{
    class Pos2
    {
        public static readonly Pos2 N = new Pos2(0, -1);
        public static readonly Pos2 E = new Pos2(1, 0);
        public static readonly Pos2 S = new Pos2(0, 1);
        public static readonly Pos2 W = new Pos2(-1, 0);
        public static readonly Pos2 NE = new Pos2(1, -1);
        public static readonly Pos2 SE = new Pos2(1, 1);
        public static readonly Pos2 SW = new Pos2(-1, 1);
        public static readonly Pos2 NW = new Pos2(-1, -1);

        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Pos2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Pos2() : this(0, 0) { }

        public Pos2 Cpy()
        {
            return new Pos2(x, y);
        }

        public Pos2 Set(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public Pos2 Set(Pos2 other)
        {
            this.x = other.x;
            this.y = other.y;
            return this;
        }

        public Pos2 Add(int x, int y)
        {
            this.x += x;
            this.y += y;
            return this;
        }

        public Pos2 Add(Pos2 other)
        {
            this.x += other.x;
            this.y += other.y;
            return this;
        }

        public Pos2 Sub(int x, int y)
        {
            this.x -= x;
            this.y -= y;
            return this;
        }

        public Pos2 Sub(Pos2 other)
        {
            this.x -= other.x;
            this.y -= other.y;
            return this;
        }

        public override string ToString()
        {
            return ("(" + x + ", " + y + ")");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pos2 other = obj as Pos2;
            if ((System.Object)other == null)
            {
                return false;
            }

            return x == other.x && y == other.y;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + x.GetHashCode();
            hash = (hash * 7) + y.GetHashCode();
            return hash;
        }
    }
}
