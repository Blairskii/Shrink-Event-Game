public interface IPlayerSizeListener // Interface for objects that want to listen to player size changes
{ 
    void OnPlayerBecameSmall();
    void OnPlayerBecameLarge();
}