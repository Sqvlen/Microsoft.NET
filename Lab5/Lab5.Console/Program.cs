using Lab5.Infrastructure.Composite;

namespace Lab5.Console;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var client = new Client();
        
        var text = new Text("Kruto-klas");
        var paragraph1 = new Paragraph();

        var sentence1 = new Sentence();
        var sentence2 = new Sentence();

        var word1 = new Word("test");
        var word2 = new Word("foo");
        var mark1 = new Mark(",");
        
        sentence1.Add(word1);
        sentence1.Add(mark1);
        sentence1.Add(word1);
        
        var word3 = new Word("bam");
        var word4 = new Word("too");
        var mark3 = new Mark(",");
        
        sentence2.Add(word3);
        sentence2.Add(mark3);
        sentence2.Add(word4);
        
        paragraph1.Add(sentence1);
        paragraph1.Add(sentence2);
        
        var paragraph2 = new Paragraph();

        var sentence3 = new Sentence();
        var sentence4 = new Sentence();
        var sentence5 = new Sentence();
        
        var word5 = new Word("test");
        var word6 = new Word("foo");
        var mark4 = new Mark(",");
        
        sentence3.Add(word1);
        sentence3.Add(mark1);
        sentence3.Add(word1);
        
        var word7 = new Word("bam");
        var word8 = new Word("too");
        var mark6 = new Mark(",");
        
        sentence4.Add(word7);
        sentence4.Add(mark6);
        sentence4.Add(word8);
        
        paragraph2.Add(sentence3);
        paragraph2.Add(sentence4);
        paragraph2.Add(sentence5);
        
        text.Add(paragraph1);
        text.Add(paragraph2);
        
        client.Execute(text);
    }
}