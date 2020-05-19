using System.Collections.Generic;

namespace Design.LeetCode.Medium
{
    //Leet 146 https://leetcode.com/problems/lru-cache/
    public class LRUCache
    {
 
        int capacity = 0;
        int count = 0;
        Dictionary<int, int> map;// = new Dictionary<int, int>(capacity);
        LinkedList<int> lruList = new LinkedList<int>();
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            map = new Dictionary<int, int>(capacity);
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
                return -1;

            var value = map[key];
            lruList.Remove(key);
            lruList.AddLast(key);
            //MoveToEnd(key);

            return value;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                map[key] = value;
                lruList.Remove(key);
                lruList.AddLast(key);
            }
            else
            {
                map.Add(key, value);
                AddLast(key);
            }
        }

        void AddLast(int key)
        {
            lruList.AddLast(key);
            if (count != capacity)
                count += 1;
            else
            {
                var keytoRemove = lruList.First.Value;
                lruList.RemoveFirst();
                map.Remove(keytoRemove);
            }
        }
    }
}
