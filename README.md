# Data Structures Lab in C#

This repository is a personal learning lab where I implement data structures from scratch using C# and build small real-world mini projects to understand how each structure works internally.

The goal is not only to use built-in collections, but to understand the logic behind them: memory behavior, Big O complexity, insertion/deletion rules, traversal, resizing, references, and real use cases.

---

## Objectives

- Understand core data structures deeply
- Implement each structure from scratch in C#
- Practice time and space complexity
- Compare custom implementations with C# built-in collections
- Build small mini projects using the right data structure
- Improve problem-solving and software engineering thinking

---

## Implemented Data Structures

### Dynamic Array

Folder: `DynamicArray`

A custom generic dynamic array similar to `List<T>`.

Implemented features:

- Add
- Insert at index
- Delete at index
- Search
- Contains
- Get by index
- Update by index
- Automatic resizing
- Capacity and size tracking

Key concepts:

- Contiguous memory
- Capacity vs size
- Resizing by doubling
- Shifting elements
- Amortized O(1) insertion at end

---

### Matrix Utility

Folder: `Matrix`

A custom matrix utility class for practicing 2D array logic.

Implemented features:

- Set value
- Get value
- Display matrix
- Fill sequentially
- Sum all values
- Row sum
- Column sum
- Search
- Main diagonal sum
- Secondary diagonal sum
- Transpose
- Symmetry check
- Identity matrix check

Key concepts:

- Rows and columns
- 2D indexing
- Matrix traversal
- Diagonal rules
- Transpose logic
- O(rows × columns) traversal

---

### Stack

Folder: `StackImplement`

A custom generic stack implementation.

Implemented features:

- Push
- Pop
- Peek
- IsEmpty
- Display
- Clear
- Dynamic resizing

Key concepts:

- LIFO: Last In, First Out
- Top element
- Undo/redo logic
- O(1) push/pop behavior

---

### Simple Queue

Folder: `QueueImplement`

A custom generic queue using simple array shifting.

Implemented features:

- Enqueue
- Dequeue
- Peek
- IsEmpty
- Display
- Dynamic resizing

Key concepts:

- FIFO: First In, First Out
- Enqueue at rear
- Dequeue from front
- Shifting cost O(n)

---

### Circular Queue

Folder: `CircularQueue`

A custom generic circular queue implementation.

Implemented features:

- Enqueue
- Dequeue
- Peek
- IsEmpty
- Display
- Resize while preserving logical order

Key concepts:

- Front pointer
- Rear pointer
- Wrap-around indexing
- Modulo operation
- O(1) enqueue and dequeue
- Avoiding shifting

---

### Singly Linked List

Folder: `LinkedListImplement`

A custom generic singly linked list.

Implemented features:

- AddFirst
- AddLast
- InsertAfter
- Delete
- Contains
- Display
- Count
- Head and Tail references

Key concepts:

- Node structure
- Value + Next reference
- Head pointer
- Tail pointer
- Link manipulation instead of shifting
- O(1) AddFirst
- O(1) AddLast with Tail

---

### Doubly Linked List

Folder: `DoublyLinkedList`

A custom generic doubly linked list.

Implemented features:

- AddFirst
- AddLast
- InsertAfter
- Delete
- DisplayForward
- DisplayBackward
- Count
- Head and Tail references

Key concepts:

- Node with Previous and Next references
- Forward and backward traversal
- Bidirectional linking
- Easier deletion when node reference is known
- Extra memory cost for Previous pointer

---

### Circular Linked List

Folder: `CircularLinkedList`

A custom generic circular linked list.

Implemented features:

- AddFirst
- AddLast
- Delete
- Contains
- Display
- Count
- Head and Tail references

Key concepts:

- Last node points back to Head
- No null ending
- Circular traversal
- Turn-based rotation logic
- Preserving the invariant: Tail.Next = Head

---

## Mini Projects

### Undo/Redo Text Editor

Folder: `MiniProjects/UndoRedoTextEditor`

A small console-based project that uses two stacks to simulate undo and redo behavior.

Features:

- Type text
- Undo last action
- Redo undone action
- Show current text
- Clear redo history after new action

Data structure used:

- Stack

Key concept:

- Undo and redo both use LIFO behavior.

---

## Planned Mini Projects

The next mini projects will connect each data structure to a real-world use case.

### Printer Queue System

Data structure:

- Queue

Practice:

- Add print job
- Process next job
- Peek next job
- Display waiting jobs

---

### Call Center Waiting Buffer

Data structure:

- Circular Queue

Practice:

- Add caller
- Serve caller
- Use wrap-around behavior
- Avoid shifting

---

### Music Playlist Manager

Data structure:

- Singly Linked List

Practice:

- Add song
- Delete song
- Insert song after another
- Search song
- Display playlist

---

### Browser Back/Forward History

Data structure:

- Doubly Linked List

Practice:

- Visit page
- Go back
- Go forward
- Clear forward history after visiting new page

---

### Turn-Based Game Rotation

Data structure:

- Circular Linked List

Practice:

- Add players
- Remove players
- Move to next player
- Keep rotating turns

---

### Student Grades Manager

Data structure:

- Dynamic Array

Practice:

- Add grade
- Insert grade
- Delete grade
- Update grade
- Average, max, min

---

### Cinema Seat Reservation

Data structure:

- Matrix

Practice:

- Reserve seat
- Cancel reservation
- Count available seats
- Display seating grid

---

## Complexity Summary

| Data Structure | Access | Search | Insert | Delete |
|---|---:|---:|---:|---:|
| Dynamic Array | O(1) | O(n) | O(n) middle / O(1) end amortized | O(n) |
| Matrix | O(1) by row/column | O(rows × cols) | Depends on operation | Depends on operation |
| Stack | O(1) top | O(n) if searching | O(1) push amortized | O(1) pop |
| Queue | O(1) front | O(n) | O(1) enqueue amortized | O(n) simple dequeue |
| Circular Queue | O(1) front/rear | O(n) | O(1) enqueue | O(1) dequeue |
| Singly Linked List | O(n) | O(n) | O(1) with reference | O(1) with previous/reference |
| Doubly Linked List | O(n) | O(n) | O(1) with reference | O(1) with reference |
| Circular Linked List | O(n) | O(n) | O(1) at head/tail | O(n) by value |

---

## Learning Notes

This repository follows a simple learning strategy:

1. Understand the concept
2. Visualize the memory model
3. Analyze time and space complexity
4. Implement from scratch
5. Test edge cases
6. Build a small real-world project
7. Commit progress with meaningful messages

---

## Current Roadmap

Completed:

- Dynamic Array
- Matrix
- Stack
- Queue
- Circular Queue
- Singly Linked List
- Doubly Linked List
- Circular Linked List
- Undo/Redo Text Editor mini project

Next:

- Printer Queue System
- Call Center Waiting Buffer
- Music Playlist Manager
- Browser History System
- Turn-Based Game Rotation
- C# Collections recap
- HashTable / Dictionary / HashSet
- Trees
- Graphs
- Heap and Priority Queue

---

## Tech Stack

- Language: C#
- Platform: .NET
- Type: Console applications / class libraries
- Version Control: Git and GitHub

---

## Purpose

This repository is part of my journey to strengthen my computer science fundamentals and become better at software engineering, problem-solving, and writing efficient code.

The focus is on understanding how data structures work internally, not only how to use built-in collections.
