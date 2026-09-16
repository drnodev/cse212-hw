using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: A (1), B (3), C (2).
    // Dequeue three times.
    // Expected Result: B, C, A (highest priority first, each item removed after it is returned).
    // Defect(s) Found: First Dequeue returned B correctly, but the second Dequeue also returned B
    // (expected C). Dequeue found the highest priority item but never removed it from the list
    // (missing _queue.RemoveAt(highPriorityIndex)), so the same item was returned every time.
    public void TestPriorityQueue_DequeueHighestAndRemoves()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
 
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where the highest priority is at the BACK of the queue:
    // A (1), B (2), C (9). Dequeue once.
    // Expected Result: C
    // Defect(s) Found: Dequeue returned B instead of C. The search loop used
    // "index < _queue.Count - 1", which stops one item early and never examines the last item
    // in the queue. Fixed to "index < _queue.Count".
    public void TestPriorityQueue_HighestPriorityAtBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);
 
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with a tie for highest priority: A (5), B (5), C (1), D (0).
    // Dequeue twice.
    // Expected Result: A then B (FIFO - the one closest to the front wins the tie).
    // Defect(s) Found: First Dequeue returned B instead of A. The comparison used ">=", so a
    // later item with an EQUAL priority replaced the earlier one. Fixed to ">" so the first
    // item with the highest priority is kept.
    public void TestPriorityQueue_TieUsesFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 0);
 
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

     [TestMethod]
    // Scenario: Enqueue items A (3), B (1), C (2) and check the string representation.
    // Expected Result: "[A (Pri:3), B (Pri:1), C (Pri:2)]" - items stay in insertion order
    // regardless of priority.
    // Defect(s) Found: None. Enqueue correctly adds to the back of the queue.
    public void TestPriorityQueue_EnqueueAddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);
 
        Assert.AreEqual("[A (Pri:3), B (Pri:1), C (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue a single item, dequeue it, then dequeue again from the now-empty queue.
    // Expected Result: First Dequeue returns "A"; second Dequeue throws InvalidOperationException
    // with the message "The queue is empty."
    // Defect(s) Found: The second Dequeue returned "A" again instead of throwing, because the
    // item was never removed from the queue (same missing RemoveAt defect as the first test).
    // After adding RemoveAt, the exception is thrown correctly.
    public void TestPriorityQueue_DequeueUntilEmptyThrows()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        Assert.AreEqual("A", priorityQueue.Dequeue());
 
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Dequeue from a brand new, empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. The empty-queue check and exception message were already correct.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();
 
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}