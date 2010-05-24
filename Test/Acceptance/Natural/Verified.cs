using System;

namespace FluentSpec.Test.Acceptance.Natural {

    public static class Verified {

        public static bool That(Action Action) {
            try {
                Action.Invoke();
                return true;
            } catch {
                return false;
            }
        }
    }
}