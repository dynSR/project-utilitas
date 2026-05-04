using System;
using UnityEngine;
using Utilitas;

public class FixedSizeStack<T> {
    private readonly T[] collection;
    public int Count { get; private set; }
    private bool IsFull => Count >= collection.Length;

    public FixedSizeStack(int maxSize) {
        if (maxSize <= 0) throw new ArgumentException($"{nameof(maxSize)} must be greater than 0.", nameof(maxSize));
        collection = new T[maxSize];
        Count = 0;
    }

    /// <summary>
    /// Adds an element at the top.
    /// </summary>
    public void Push(T item) {
        if (IsFull) {
            Debug.Log($"{nameof(FixedSizeStack<T>)} is full. Cannot push {item}.");
            return;
        }

        collection[Count++] = item;
    }

    /// <summary>
    /// Removes and returns the element at the top.
    /// </summary>
    /// <returns>The removed element.</returns>
    public T Pop() {
        if (collection.IsEmpty()) Debug.LogError($"{nameof(FixedSizeStack<T>)} is empty. Cannot pop.");
        return collection[--Count];
    }

    /// <summary>
    /// Returns top element without removing it.
    /// </summary>
    /// <returns>The top element.</returns>
    public T Peek() {
        if (collection.IsEmpty()) Debug.LogError($"{nameof(FixedSizeStack<T>)} is empty. Cannot peek.");
        return collection[Count - 1];
    }

    public void Clear() {
        Count = 0;
        Array.Clear(collection, 0, collection.Length);
    }
}