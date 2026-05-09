ben # Software Engineering Term Project 2 - NUnit Testing Report

## 1. Project Overview
This solution implements three core C# classes (`FizzBuzz`, `DemeritPointsCalculator`, and `Stack<T>`) and a corresponding NUnit test project to verify their correctness. The goal was to ensure all logical paths, boundary conditions, and exception handling mechanisms were thoroughly tested using automated unit tests.

## 2. Solution Structure
The solution `TermProject2` consists of two projects:
*   **TermProject2.Core**: A Class Library containing the business logic.
*   **TermProject2.Tests**: A NUnit Test Project containing the automated tests.

## 3. Implementation and Testing Details

### Class 1: FizzBuzz
**Purpose:** Returns "Fizz", "Buzz", or "FizzBuzz" based on divisibility by 3 and 5.
**Test Strategy (`FizzBuzzTests.cs`):**
*   **Parameterized Testing:** We used `[TestCase]` to avoid code duplication for similar logic.
*   **Scenarios Covered:**
    *   Divisible by 3 only (e.g., 3, 6) -> Returns "Fizz"
    *   Divisible by 5 only (e.g., 5, 10) -> Returns "Buzz"
    *   Divisible by both 3 and 5 (e.g., 15, 30) -> Returns "FizzBuzz"
    *   Not divisible by 3 or 5 (e.g., 1, 2) -> Returns the number as a string.

### Class 2: DemeritPointsCalculator
**Purpose:** Calculates demerit points for speeding violations.
**Test Strategy (`DemeritPointsCalculatorTests.cs`):**
*   **Boundary Value Analysis:** We tested speeds right at the limit (65), just above, and at the max speed.
*   **Exception Handling:** Verified that `ArgumentOutOfRangeException` is thrown for speeds < 0 or > 300.
*   **Scenarios Covered:**
    *   Speed <= SpeedLimit (65) -> Returns 0 points.
    *   Speed > SpeedLimit -> Returns points calculated as `(Speed - SpeedLimit) / 5`.
    *   Invalid speeds (negative values or overly high speeds) -> Throws Exception.

### Class 3: Stack\<T>
**Purpose:** A generic LIFO (Last-In-First-Out) collection.
**Test Strategy (`StackTests.cs`):**
*   **Null Safety:** Verified `Push(null)` throws `ArgumentNullException`.
*   **State Verification:** Checked `Count` before and after operations.
*   **Empty State Handling:** Verified `Pop()` and `Peek()` throw `InvalidOperationException` on an empty stack.
*   **Logic Verification:**
    *   `Push`: Adds item to top.
    *   `Pop`: Returns and removes item from top.
    *   `Peek`: Returns item from top without removing it.

## 4. Test execution
All tests were written using NUnit Framework.
To execute tests, use the command:
```bash
dotnet test
```

## 5. Conclusion
All functional requirements have been met. The tests cover 100% of the public methods and critical logic paths (valid inputs, edge cases, and exceptions), ensuring the robustness of the implementation.
