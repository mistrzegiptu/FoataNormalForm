# FoataNormalForm Converter

A **C#** tool that computes the **Foata Normal Form (FNF)** of a word derived from a set of labeled transactions.  
This converter analyzes data dependencies between labeled operations and expresses their **concurrent execution structure** using the **Foata Normal Form** — a key concept in **trace theory** and **concurrency models**.

---

## 📘 Overview

The **FoataNormalForm Converter** takes an input file describing:

1. **A set of labeled transactions** (e.g., `a`, `b`, `c`, `d`)  
2. **Each transaction’s operation** on variables  
3. **A labeled alphabet** (set `A`) representing the transactions  
4. **A word** (`w`) — a sequence of transaction labels representing an execution trace  

The program computes and outputs:
- The **dependency (or independence) relation** between actions
- The **graph** in dot form
- The **Foata Normal Form** of the given word `w`

---

## 📄 Example Input

Example input file (`input.txt`):

```
(a) x := x + y
(b) y := y + 2z
(c) x := 3x + z
(d) z := y - z
A = {a, b, c, d}
w = baadcb
```

### Explanation

- **Transactions:**
  - `a`: modifies `x` and reads `y`
  - `b`: modifies `y` and reads `z`
  - `c`: modifies `x` and reads `z`
  - `d`: modifies `z` and reads `y`
- **Alphabet:** `A = {a, b, c, d}`
- **Word:** `w = baadcb`

The program determines which transactions are **independent** (can be reordered) and which are **dependent** (must remain in order), and then computes the **Foata Normal Form** accordingly.

---

## ⚙️ Usage

### 1. Prepare Input
Create a `.txt` file with the structure shown above.  
Each transaction should:
- Start with a label `(a)`, `(b)`, etc.
- Contain an assignment operation using variables.
- The last two lines must define:
  - The set of transaction labels `A`
  - The word `w`

### 2. Run the Converter
From the command line:

```bash
FoataNormalFormConverter.exe input.txt
```

or within a .NET environment:

```bash
dotnet run -- input.txt
```

### 3. Output
The output will include:
- The **dependence relation (D)**  
- The **independence relation (I)**
- The **graph** in dot form
- The computed **Foata Normal Form** of the word `w`

Example output:

```
Dependence relation D = {(a,c), (b,d), ...}
Independence relation I = {(a,b), (a,d), ...}
Dependency graph in dot format: digraph g{...
Foata Normal Form: (b)(ad)(a)(c)(b)
```

---

## 🧠 Theoretical Background

The **Foata Normal Form (FNF)** represents the structure of **concurrent processes** by grouping **independent actions** into the same parentheses level.

For a word `w`,  
if `a` and `b` are **independent** (`(a, b) ∈ I`),  
then `ab` and `ba` are equivalent traces — both belong to the same Foata class.

The **FNF** expresses this equivalence explicitly:

```
(b)(ad)(a)(c)(b)
```

Meaning:
- `b` occurs first,
- then `a` and `d` can execute concurrently,
- followed by `a`, `c`, and finally `b`.

---

## 🧪 Example Run

**Input:**
```
(a) x := x + y
(b) y := y + 2z
(c) x := 3x + z
(d) z := y - z
A = {a, b, c, d}
w = baadcb
```

**Output:**
```
Dependence relation D = {(a,c), (b,d), (a,d), (b,c), (a,a), ...}
Independence relation I = {(a,b), (c,d), ...}
Foata Normal Form: (b)(ad)(a)(c)(b)

Dependence relation: D = {(a,a),(a,c),(a,f),(b,b),(b,e),(c,a),(c,c),(c,e),(c,f),(d,d),(d,f),(e,b),(e,c),(e,e),(f,a),(f,c),(f,d),(f,f),}
Independence relation: I = {(a,b),(a,d),(a,e),(b,a),(b,c),(b,d),(b,f),(c,b),(c,d),(d,a),(d,b),(d,c),(d,e),(e,a),(e,d),(e,f),(f,b),(f,e),}
Dependency graph in dot format:
  digraph g{
  0 -> 1
  1 -> 3
  2 -> 4
  3 -> 4
  3 -> 7
  5 -> 6
  6 -> 7
  0[label=a]
  1[label=c]
  2[label=d]
  3[label=c]
  4[label=f]
  5[label=b]
  6[label=b]
  7[label=e]
  }

Foata Normal Form: FNF([w])=(adb)(cb)(c)(fe)
```

