﻿using Serilog;
using System;
using System.Collections.Generic;

namespace BrainstormSessions.Core.Model
{
    public class BrainstormSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public List<Idea> Ideas { get; } = new List<Idea>();

        public BrainstormSession()
        {
            Log.Debug("Expected 2 Debug messages in the logs");
        }

        public void AddIdea(Idea idea)
        {
            Ideas.Add(idea);
        }
    }

    public class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
