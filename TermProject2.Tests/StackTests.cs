using System;
using NUnit.Framework;
using TermProject2.Core;

namespace TermProject2.Tests
{
    [TestFixture]
    public class StackTests
    {
        private TermProject2.Core.Stack<string> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new TermProject2.Core.Stack<string>();
        }

        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            _stack.Push("a");
            
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTop()
        {
            // Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            var result = _stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTop()
        {
            // Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            _stack.Pop();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTop()
        {
            // Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            var result = _stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesnotRemoveObjectOnTop()
        {
            // Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            _stack.Peek();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Push_EmptyString_ShouldAddEmptyString()
        {
            // Arrange
            string empty = "";
            
            // Act
            _stack.Push(empty);
            
            // Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
            Assert.That(_stack.Peek(), Is.EqualTo(""));
        }

        [Test]
        public void PushPop_VerificationOfLIFOOrder_ShouldReturnInReverseOrder()
        {
            // Arrange
            _stack.Push("first");
            _stack.Push("second");
            _stack.Push("third");

            // Act & Assert
            // Expect "third"
            Assert.That(_stack.Pop(), Is.EqualTo("third"));
            
            // Expect "second"
            Assert.That(_stack.Pop(), Is.EqualTo("second"));
            
            // Expect "first"
            Assert.That(_stack.Pop(), Is.EqualTo("first"));
            
            // Stack should be empty now
            Assert.That(_stack.Count, Is.EqualTo(0));
        }
    }
}
