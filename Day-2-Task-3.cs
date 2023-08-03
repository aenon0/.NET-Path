void PalindromeOrNot(string word)
{
    int left = 0, right = word.Length - 1;
    bool checkPalindrome = true;
    while (left < right)
    {
        if (word[left] != word[right])
        {
            checkPalindrome = false;
        }
        left += 1; right -= 1;
    }

    if (checkPalindrome)
    {
        Console.WriteLine("It's palindrome.");
    }
    else
    {
        Console.WriteLine("It's not a palindrome.");
    }
}

Console.WriteLine("Enter the word.");
string word = Console.ReadLine();
PalindromeOrNot(word);

