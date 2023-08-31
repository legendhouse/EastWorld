using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Embedding
{
    private static int EMBEDDING_SIZE = 1536;
    public double[] embedding;

    public Embedding(double[] embedding)
    {
        this.embedding = embedding;
    }

    public Embedding()
    {
        this.embedding = new double[EMBEDDING_SIZE];
    }

    public override string ToString()
    {
        return string.Format("embedding values: [{0} ...]", string.Join(", ", embedding.Take(10)));
    }
}