using System.Linq;
using System.Collections.Generic;
using System;

namespace RockPaperScissors.Domain
{
    public class GameOptions
    {
        private Options tail;
        private Options head;
        private int count;
        public List<Options> Options;

        internal GameOptions()
        {
            List<Options> Nodes = new List<Options>();
        }

        internal Options FindOptionByKey(int keyOption)
        {
            return Options.Find(x => x.key == keyOption);
        }

        internal string FindOptionNameByKey(int keyOption)
        {
            return Options.Find(x => x.key == keyOption).value;
        }

        internal Options FindOptionThatDefeatsByKey(int keyOption)
        {
            return Options.Find(x => x.defeats.ContainsKey(keyOption));
        }

        internal void AddNewOption(string nameOption, int defeatOption)
        {
            int newKey = Options.Count + 1;

            var optionDefeated = Options.Find(x => x.key == defeatOption);

            var newOption = new Options(nameOption.ToUpper(), newKey);
            newOption.defeats.Add(optionDefeated.key, optionDefeated.value);

            Options.Add(newOption);
            count++;
        }

        internal int Count()
        {
            return count;
        }


        internal void AddLast(string description, int key)
        {
            var node = new Options(description, key);

            if (head == null)
                head = tail = node;
            else
            {
                tail.next = node;
                tail = node;
            }

            UpdateNodes(node);

            count++;
        }

        private void UpdateNodes(Options newNode)
        {
            Options.Add(newNode);
        }

        private void UpdateListReference(Options node, int i)
        {
            if (node.next != null)
            {
                node.key = i;
                i++;
                UpdateListReference(node.next, i);
            }
            else
            {
                node.key = i;
            }
        }

        internal void UpdateDefeatOption(int chosenOption, int newDefeatOption, bool isAddNew = false)
        {
            var chosenOne = Options.Find(x => x.key == chosenOption);
            var newDefeatOne = Options.Find(x => x.key == newDefeatOption);

            if (!isAddNew)
            {
                chosenOne.defeats.Clear();
            }
            chosenOne.defeats.Add(newDefeatOne.key, newDefeatOne.value);
        }

        internal List<Options> FilterOptions(int key)
        {
            return Options.FindAll(x => x.key != key);
        }

        internal List<Options> ListOptions()
        {
            return Options;
        }
    }
}
