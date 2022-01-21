# Testing & Dependencies

Decomposition = Making smaller pieces of code - makes testing easier. Just as smaller sentences help us convey our intentions better.

Testing = Specifying the output - drives us to decompose better.

Welcome to Test Driven Development. The positive cycle of Testability and Decomposition.

## Make the tests fail

This exercise has a set of buggy implementations. The implementations also have tests (asserts) which pass, despite the bugs. They are 'weak' tests. Such tests are ineffective - you will need to manually check the code anyway.

Your task is to _strengthen the tests_ and make them all fail. **Do not fix the implementation. Do not pass the tests**

In this repository, the workflows are designed to make the Action fail when any of the tests pass.

## Hints

`tshirts` has a simple error. It tries to classify T-shirt sizes based on shoulder-measurements. It leaves out one input value. Add a test to catch that.

`misaligned` tries to print a map from numbers to colors, as per [this Wiki](https://en.wikipedia.org/wiki/25-pair_color_code). However, the numeric values and the separator (`|`) are misaligned. The functionality is not efficiently testable - the fault needs human inspection. Think of separating the concerns and testing them individually.

`alerter` sends out an alert over the network when a threshold is breached. The code stubs the network-sendng part, so that we can test without the network. However, there is a mistake in its error-handling and the test doesn't bother to check that part of the code. Adapt the code to cover the error condition and fail due to the mistake.

# Extra challenge

The `alerter` mixes stub and test-code with production code. If we need to switch from the stub to integrate the real network communication, production code needs to be changed.
Can you think of a way to separate things - so that the production code doesn't change while switching from the test-environment to the integration-environment?
