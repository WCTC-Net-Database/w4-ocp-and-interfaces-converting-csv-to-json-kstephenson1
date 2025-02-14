using w4_assignment_ksteph.Characters;

namespace w4_assignment_ksteph.FileIO;

public interface ICharacterIO
{
    List<Character> ReadCharacers();
    void WriteCharacters(List<Character> characters);
}
