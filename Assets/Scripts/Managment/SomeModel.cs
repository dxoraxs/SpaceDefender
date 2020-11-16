using UniRx;

public class SomeModel<T> {
    public ReactiveProperty<T> count { get; private set; }
    
    public SomeModel (T i) {
        count = new ReactiveProperty<T> (i);
    }
}