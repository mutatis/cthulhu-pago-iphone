using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IJumpable
{
    void TryToJump();

    bool ApplyJump();

    bool ApplyDoubleJump();

    void ReturnedToGround();

    bool CheckGround();
}
