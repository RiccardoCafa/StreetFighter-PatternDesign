using UnityEngine;
using System.Collections;

namespace Assets.Scripts.EventArgs
{
    public class DeathArgs
    {
        public DeathArgs(IGameStrategy sender)
        {
            Sender = sender;
        }

        public IGameStrategy Sender { get; set; }
    }
}