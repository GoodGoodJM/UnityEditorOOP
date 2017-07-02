//외부 테스트용 코드. 라테일 프로젝트 안에선 필요 없음.

using System;

#if !GHOSTSOUL
namespace GGM.Editor.UI
{
    public static class ActionHelper
    {
        public static void Execute(this Action self)
        {
            if (self != null)
                self();
        }

        public static void Execute<T>(this Action<T> self, T value)
        {
            if (self != null)
                self(value);
        }

        public static void Execute<T1, T2>(this Action<T1, T2> self, T1 value1, T2 value2)
        {
            if (self != null)
                self(value1, value2);
        }
    }
}
#endif