# RecursiveExpressionTreePy

## Features

- Parses fully parenthesized expressions like `((2+3)*(4-1))`
- Supports `+`, `-`, `*`, and `/`
- Recursively evaluates tree structure

## How It Works

- The input string is tokenized.
- Each operator becomes an internal node.
- Each number becomes a leaf node.
- The tree is built recursively and evaluated from root.
