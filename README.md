# SlotMachinePrototype
Slot Machine Prototype with visual spinning using Object Pooling System

Unity Version:- 2021.3.8f1
Orientation:- Portraite 1920*1080
Scene name:- SlotMachine
Run Instruction:- Open SlotMachine scene and run unity editor.



Scripts Explanation

Symbol.cs
This script contains data for a symbol, including:
an icon (sprite),
a flag isSpecial to indicate if the symbol is special,
and a method to generate a random number only if the symbol is special.





Reels.cs
This script contains:
List_Symbol: a list of 5 RectTransform symbols that visually move vertically using DOTween.
The script also uses object pooling to reuse symbol objects, instead of instantiating and destroying prefabs.



GameManager.cs
This script handles the overall slot machine logic. It includes:
A reference to the ScriptableObject symbol data.
A Spin button method that starts the slot machine spin.
Initialization of all Reels from this script.

After spinning:
It finds visible symbols on the reels.
Highlights 3 or more matching symbols.
Calls GetRandomNumber() if the symbol is special and matches the condition.
Also includes logic to reset reels, clear symbol lists, and clean up data before the next spin.



