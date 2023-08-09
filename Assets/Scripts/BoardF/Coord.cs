using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardF {
    struct Coord {
        public int x;
        public int y;
        
        public Coord (int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Coord (int size) {
            x = size - 1;
            y = size - 1;
        }

        public bool OnBoard (int size) {
            if (x < 0 || x > size -1) return false;
            if (y < 0 || y > size -1) return false;
            return true;
        }

        public Coord Add (int sx, int sy) {
            return new Coord (x + sx, y + sy);
        }
    }    
}