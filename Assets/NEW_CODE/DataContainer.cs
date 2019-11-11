using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;   
    [System.Serializable]
    public class DataContainer<Key, Value>
    { 
        public List<Value> list;
        public Dictionary<Key, Value> map;

        public DataContainer()
        {
            list = new List<Value>();
            map = new Dictionary<Key, Value>();
        }

        public void Clear()
        {
            list.Clear();
            map.Clear();
        }
        public void LoadList(List<Value> values, string keyName)
        {
            Clear();
            if (values.Count == 0) return;
            for (int i = 0; i < values.Count; i++)
            {
                var type = values[i].GetType();
                var fields = type.GetFields();
                foreach (var n in fields)
                {
                    if (n.Name == keyName)
                    {
                        Add((Key)n.GetValue(values[i]), values[i]);
                    }
                }
            }
        }

        public void CopyToList(List<Value> targetList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                targetList.Add(list[i]);
            }
        }

        public void Add(Key key, Value value)
        {
            if (IsExist(key) == true)
            {

            }
            else
            {
                map.Add(key, value);
                list.Add(value);
            }
        }

        public Value Get(Key key)
        {
            if (IsExist(key))
                return map[key];
            else
                return (default);
        }


        public void Remove(Key key)
        {
            if (IsExist(key) == true)
            {
                var value = map[key];
                map.Remove(key);
                list.Remove(value);
            }

            else
            {

            }
        }

        public bool IsExist(Key key)
        {
            if (map.ContainsKey(key) == false)
            {
                return false;
            }
            else
                return true;
        }
    }
 