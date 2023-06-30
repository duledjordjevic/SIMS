﻿using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service
{
    public interface IMemberService
    {
        void Add(Member member);
        Member Get(int id);
        Dictionary<int, Member> GetAll();
        void Remove(int id);
        void Update(Member member);
        Member? GetByAccountId(int id);
    }
}