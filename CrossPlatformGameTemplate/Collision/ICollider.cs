namespace SuperMario.Collision
{
    public interface ICollider
    {
        ICollisions Collide(object object1, object object2);
    }

    public interface ICollisions {

    }
}
