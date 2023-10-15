using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protocols
{
    public class Packets
    {
        public class req_scores
        {
            public string id;
            public int score;
        }
        public class res_scores
        {
            public int cmd;
            public string message;
        }
        public class user
        {
            public string id;
            public int score;
        }
        public class res_scores_id : res_scores
        {
            public user result;
        }
    }
}
