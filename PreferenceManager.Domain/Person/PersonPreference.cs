using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.Domain.Person;

public class PersonPreference
{
     public Person Person;
     public Preference.Preference Preference { get; }
     public string Content;
     public string? EncryptedKey;

     public PersonPreference(Person person, string content, string? encryptedKey, Preference.Preference preference)
     {
          Person = person;
          Content = content;
          EncryptedKey = encryptedKey;
          Preference = preference;
     }

     public static PersonPreference CreatePersonPreference(Person person, string content, Preference.Preference preference)
     {
          string encryptedKey = null;
          if (preference.Encrypted)
          {
               encryptedKey = GenerateEncryptedKeyAes();
               content = EncryptValue(encryptedKey, content);
          }

          return new PersonPreference(person, content, encryptedKey, preference);
     }

     private static string GenerateEncryptedKeyAes()
     {
          return "encryptionIvParameter";
     }

     private static string EncryptValue(string key, string content)
     {
          // TODO encryptContet
          return content;
     }
}