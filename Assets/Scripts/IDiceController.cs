
using System.Collections;

public interface IDiceController
{
    public Enemy GetDice();
    public void SetDice(Enemy enemy);
    public IEnumerator Attacke(IEnemyController enemy);
}
