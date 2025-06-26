using System;
using System.Collections.Generic;

namespace ProgPOEP3
{
    public static class TopicHelper
    {
        private static readonly List<string> knownTopics = new List<string>
        {
            "password", "phishing", "privacy", "scam", "malware", "vpn", "two-factor",
            "publicwifi", "updates", "encryption", "socialengineering", "backup",
            "firewalls", "ransomware", "securebrowsing", "credentials", "insiderthreats",
            "dataprivacy", "passwordmanagers", "zerotrust", "botnets", "mobilesecurity",
            "physicalsecurity", "securityawareness", "threatdetection", "incidentresponse",
            "common-cyberattacks", "elements-of-cybersecurity", "dns", "firewall-detailed",
            "vpn-detailed", "malware-sources", "email-work", "active-passive-attacks",
            "social-engineering-detailed", "hackers-types", "encryption-decryption",
            "plaintext-cleartext", "block-cipher", "cia-triangle", "three-way-handshake",
            "identity-theft-prevention", "hashing-functions", "two-factor-authentication",
            "xss", "shoulder-surfing", "hashing-vs-encryption",
            "information-security-vs-assurance", "https-vs-ssl", "system-hardening",
            "spear-phishing", "perfect-forward-secrecy", "mitm-prevention",
            "ransomware-detailed", "public-key-infrastructure", "spoofing",
            "server-hacking-steps", "sniffing-tools", "sql-injection", "ddos",
            "arp-poisoning-prevention", "proxy-firewall", "ssl-encryption",
            "penetration-testing", "public-wifi-risks", "diffie-hellman-vs-rsa",
            "asymmetric-encryption-examples", "vulnerability-vs-exploit",
            "risk-vulnerability-threat", "phishing-prevention", "forward-secrecy"
        };

        public static string ExtractTopic(string sentence)
        {
            sentence = sentence.ToLower();
            foreach (var topic in knownTopics)
            {
                if (sentence.Contains(topic.ToLower()))
                    return topic;
            }
            return null;
        }
    }
}
