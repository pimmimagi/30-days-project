// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;

namespace Doozy.Runtime.Reactor.Targets
{
    [Serializable]
    public abstract class ReactorMetaColorTarget<T> : ReactorColorTarget
    {
        /// <summary> Color target </summary>
        public T Target;
        
        /// <summary> Returns TRUE if the Target reference is not null </summary>
        public override bool hasTarget => Target != null;
    }
}
