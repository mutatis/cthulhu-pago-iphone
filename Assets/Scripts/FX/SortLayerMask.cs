using System;
using System.Runtime.CompilerServices;
//using UnityEditor;
//using UnityEditorInternal;

namespace UnityEngine
{
    public struct SortLayerMask
    {
        //
        // Fields
        //
        private int m_Mask;

        //
        // Properties
        //
        public int value
        {
            get
            {
                return this.m_Mask;
            }
            set
            {
                this.m_Mask = value;
            }
        }
        
        //
        // Static Methods
        //
//        [WrapperlessIcall]
//        [MethodImpl (MethodImplOptions.InternalCall)]
//        public static extern string LayerToName (int layer);
        
//        [WrapperlessIcall]
//        [MethodImpl (MethodImplOptions.InternalCall)]
//        public static extern int NameToLayer (string layerName);
        
        //
        // Operators
        //
        public static implicit operator SortLayerMask (int intVal)
        {
            SortLayerMask result;
            result.m_Mask = intVal;
            return result;
        }
        
        public static implicit operator int (SortLayerMask mask)
        {
            return mask.m_Mask;
        }
    }
}