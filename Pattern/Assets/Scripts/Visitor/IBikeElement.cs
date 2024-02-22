using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Visitor
{
    public interface IBikeElement
    {
        void Accept(IVisitor visitor);
    }
}
