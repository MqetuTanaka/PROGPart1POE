using System;
using System.Collections.Generic;

namespace ProgPOEP3
{
    public static class CyberSecurityResponses
    {
        private static readonly Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["password"] = new List<string>
        {
            "🔒 Use long passwords with letters, numbers, and special characters.",
            "🔒 Enable password managers to generate/stor3 unique passwords.",
            "🔒 Change passwords after security breaches or suspicious activity."
        },
        ["phishing"] = new List<string>
        {
            "🐟 Verify sender identity by checking email addresses carefully.",
            "🐟 Avoid clicking links in unsolicited messages; type URLs manually.",
            "🐟 Use email filters and report phishing attempts to your provider."
        },
        ["privacy"] = new List<string>
        {
            "👤 Regularly review privacy settings on social media.",
            "👤 Be cautious about sharing personal information online.",
            "👤 Use privacy-focused browsers and extensions."
        },
        ["scam"] = new List<string>
        {
            "🚫 Be wary of unsolicited offers or deals that seem too good to be true.",
            "🚫 Verify the legitimacy of websites and services before sharing information.",
            "🚫 Report scams to relevant authorities or platforms."
        },
        ["malware"] = new List<string>
        {
            "👾 Install reputable antivirus with real-time protection.",
            "👾 Use system hardening to reduce attack surface.",
            "👾 Enable automatic updates for OS, browsers, and applications."
        },
        ["vpn"] = new List<string>
        {
            "🌐 Encrypts internet traffic and hides your IP address.",
            "🌐 Essential for public Wi-Fi security and bypassing geo-restrictions.",
            "🌐 Choose VPNs with strong encryption protocols (OpenVPN, WireGuard)."
        },
        ["two-factor"] = new List<string>
        {
            "🔐 Combine something you know (password) with something you have (authenticator).",
            "🔐 Prefer app-based authenticators over SMS-based 2FA.",
            "🔐 Enable 2FA for critical accounts even if it's optional."
        },
        ["updates"] = new List<string>
        {
            "🔄 Keep your operating system, applications, and firmware up to date.",
            "🔄 Enable automatic updates to ensure you have the latest security patches.",
            "🔄 Regularly check for updates manually if automatic updates are disabled."
        },
        ["encryption"] = new List<string>
        {
            "🔒 Converts plaintext to ciphertext using mathematical algorithms.",
            "🔒 AES-256 is currently considered secure for most applications.",
            "🔒 Always use end-to-end encryption for sensitive communications."
        },
        ["socialengineering"] = new List<string>
        {
            "🚫 Be cautious of unsolicited requests for information.",
            "🚫 Verify the identity of the requester through official channels.",
            "🚫 Educate yourself and your team about common social engineering tactics."
        },
        ["backup"] = new List<string>
        {
            "💾 Follow 3-2-1 backup rule: 3 copies, 2 media types, 1 offsite.",
            "💾 Test backups regularly to ensure they're usable.",
            "💾 Store backups physically separate from primary systems."
        },
        ["firewalls"] = new List<string>
        {
            "🔥 Network security system monitoring incoming/outgoing traffic.",
            "🔥 Configure rules to block unauthorized access while allowing legitimate traffic.",
            "🔥 Use both hardware (network) and software (endpoint) firewalls."
        },
        ["ransomware"] = new List<string>
        {
            "💀 Back up data regularly using 3-2-1 strategy (3 copies, 2 media types, 1 offsite).",
            "💀 Use ransomware detection tools and monitor system behavior.",
            "💀 Never pay ransom demands as it encourages further attacks."
        },
        ["securebrowsing"] = new List<string>
        {
            "🌐 Use HTTPS for secure web browsing.",
            "🌐 Keep your browser and plugins up to date.",
            "🌐 Avoid clicking on suspicious links or downloading unknown files."
        },
        ["credentials"] = new List<string>
        {
            "👤 Use unique credentials for different services.",
            "👤 Enable multi-factor authentication (MFA) where possible.",
            "👤 Regularly update and securely store your credentials."
        },
        ["insiderthreats"] = new List<string>
        {
            "🚫 Implement strict access controls and least privilege principles.",
            "🚫 Conduct regular security audits and monitor for unusual activity.",
            "🚫 Educate employees about the risks and signs of insider threats."
        },
        ["dataprivacy"] = new List<string>
        {
            "👤 Regularly review privacy settings on social media.",
            "👤 Be cautious about sharing personal information online.",
            "👤 Use privacy-focused browsers and extensions."
        },
        ["passwordmanagers"] = new List<string>
        {
            "🔑 Use a reputable password manager to generate and store complex passwords.",
            "🔑 Enable biometric or strong master passwords for your password manager.",
            "🔑 Regularly review and update your stored passwords."
        },
        ["zerotrust"] = new List<string>
        {
            "🚫 Assume no trust and verify all access requests.",
            "🚫 Implement micro-segmentation to limit lateral movement.",
            "🚫 Continuously monitor and log access and activities."
        },
        ["botnets"] = new List<string>
        {
            "🤖 Use strong endpoint protection to detect and block botnet infections.",
            "🤖 Regularly update and patch systems to close vulnerabilities.",
            "🤖 Monitor network traffic for unusual patterns indicative of botnet activity."
        },
        ["mobilesecurity"] = new List<string>
        {
            "📱 Use strong, unique passwords and enable biometric authentication.",
            "📱 Keep your device and apps up to date with the latest security patches.",
            "📱 Be cautious about downloading apps from unknown sources."
        },
        ["physicalsecurity"] = new List<string>
        {
            "🔒 Secure physical access to servers and devices.",
            "🔒 Use surveillance and access control systems.",
            "🔒 Educate employees about physical security best practices."
        },
        ["securityawareness"] = new List<string>
        {
            "🚫 Conduct regular security training and awareness programs.",
            "🚫 Use phishing simulations to test and educate employees.",
            "🚫 Encourage a culture of security and vigilance."
        },
        ["threatdetection"] = new List<string>
        {
            "🔍 Implement advanced threat detection systems like SIEM.",
            "🔍 Regularly review logs and monitor for unusual activity.",
            "🔍 Use threat intelligence feeds to stay informed about emerging threats."
        },
        ["incidentresponse"] = new List<string>
        {
            "💥 Develop and regularly update an incident response plan.",
            "💥 Conduct regular drills and simulations to test your response capabilities.",
            "💥 Ensure all team members know their roles and responsibilities."
        },
        ["common-cyberattacks"] = new List<string>
        {
            "💥 Phishing, malware, ransomware, and SQL injection are common attacks.",
            "💥 Educate yourself and your team about these threats.",
            "💥 Implement security measures to mitigate these risks."
        },
        ["elements-of-cybersecurity"] = new List<string>
        {
            "🛡️ Includes confidentiality, integrity, and availability (CIA triad).",
            "🛡️ Combines people, processes, and technology.",
            "🛡️ Regularly review and update your security strategy."
        },
        ["dns"] = new List<string>
        {
            "🌐 Translates domain names to IP addresses.",
            "🌐 Use DNSSEC to protect against DNS spoofing.",
            "🌐 Regularly update DNS records and monitor for anomalies."
        },
        ["firewall-detailed"] = new List<string>
        {
            "🔥 Network security system monitoring incoming/outgoing traffic.",
            "🔥 Configure rules to block unauthorized access while allowing legitimate traffic.",
            "🔥 Use both hardware (network) and software (endpoint) firewalls."
        },
        ["vpn-detailed"] = new List<string>
        {
            "🌐 Encrypts internet traffic and hides your IP address.",
            "🌐 Essential for public Wi-Fi security and bypassing geo-restrictions.",
            "🌐 Choose VPNs with strong encryption protocols (OpenVPN, WireGuard)."
        },
        ["malware-sources"] = new List<string>
        {
            "👾 Malicious websites, email attachments, and downloads.",
            "👾 Use reputable antivirus and anti-malware software.",
            "👾 Regularly update and patch your systems."
        },
        ["email-work"] = new List<string>
        {
            "📧 Use secure email protocols (TLS, S/MIME).",
            "📧 Regularly update and patch your email client.",
            "📧 Be cautious about clicking on links or downloading attachments."
        },
        ["active-passive-attacks"] = new List<string>
        {
            "💥 Active attacks involve direct interaction with the target.",
            "💥 Passive attacks involve monitoring and analyzing data without interaction.",
            "💥 Implement security measures to detect and prevent both types of attacks."
        },
        ["social-engineering-detailed"] = new List<string>
        {
            "🚫 Be cautious of unsolicited requests for information.",
            "🚫 Verify the identity of the requester through official channels.",
            "🚫 Educate yourself and your team about common social engineering tactics."
        },
        ["hackers-types"] = new List<string>
        {
            "💻 White hat hackers perform ethical hacking to find vulnerabilities.",
            "💻 Black hat hackers engage in malicious activities.",
            "💻 Gray hat hackers fall somewhere in between."
        },
        ["encryption-decryption"] = new List<string>
        {
            "🔒 Converts plaintext to ciphertext using mathematical algorithms.",
            "🔓 Converts ciphertext back to plaintext using decryption keys.",
            "🔒 Always use strong encryption algorithms like AES-256."
        },
        ["plaintext-cleartext"] = new List<string>
        {
            "📄 Unencrypted data that can be read directly.",
            "📄 Always encrypt sensitive data to protect it from unauthorized access.",
            "📄 Use secure communication channels to transmit plaintext data."
        },
        ["block-cipher"] = new List<string>
        {
            "🔒 Encrypts data in fixed-size blocks.",
            "🔒 Common block ciphers include AES and DES.",
            "🔒 Use block ciphers with strong key lengths and modes of operation."
        },
        ["cia-triangle"] = new List<string>
        {
            "🛡️ Confidentiality ensures data is accessible only to authorized users.",
            "🛡️ Integrity ensures data is accurate and trustworthy.",
            "🛡️ Availability ensures data is accessible when needed."
        },
        ["three-way-handshake"] = new List<string>
        {
            "🌐 SYN, SYN-ACK, ACK sequence to establish a TCP connection.",
            "🌐 Ensures reliable communication between devices.",
            "🌐 Protect against spoofing by verifying the source IP address."
        },
        ["identity-theft-prevention"] = new List<string>
{
    "👤 Regularly monitor your credit reports for suspicious activity.",
    "👤 Use strong, unique passwords and enable two-factor authentication.",
    "👤 Be cautious about sharing personal information online."
},
        ["hashing-functions"] = new List<string>
        {
            "🔒 Converts data into a fixed-size hash value.",
            "🔒 Common hashing algorithms include SHA-256 and MD5.",
            "🔒 Use hashing to store passwords securely."
        },
        ["two-factor-authentication"] = new List<string>
        {
            "🔐 Combine something you know (password) with something you have (authenticator).",
            "🔐 Prefer app-based authenticators over SMS-based 2FA.",
            "🔐 Enable 2FA for critical accounts even if it's optional."
        },
        ["xss"] = new List<string>
        {
            "💻 Cross-site scripting injects malicious scripts into web pages.",
            "💻 Use input validation and sanitization to prevent XSS.",
            "💻 Implement Content Security Policy (CSP) headers."
        },
        ["shoulder-surfing"] = new List<string>
        {
            "👀 Be aware of your surroundings and protect your screen.",
            "👀 Use privacy screens on devices.",
            "👀 Avoid entering sensitive information in public view."
        },
        ["hashing-vs-encryption"] = new List<string>
        {
            "🔒 Hashing is one-way and used for integrity checks.",
            "🔒 Encryption is two-way and used for confidentiality.",
            "🔒 Use both hashing and encryption to secure data."
        },
        ["information-security-vs-assurance"] = new List<string>
        {
            "🛡️ Information security focuses on protecting data.",
            "🛡️ Information assurance ensures data availability and integrity.",
            "🛡️ Both are critical components of a comprehensive security strategy."
        },
        ["https-vs-ssl"] = new List<string>
        {
            "🌐 HTTPS is the secure version of HTTP.",
            "🌐 SSL/TLS encrypts data transmitted over the internet.",
            "🌐 Always use HTTPS for secure web browsing."
        },
        ["system-hardening"] = new List<string>
        {
            "🔧 Disable unnecessary services and ports.",
            "🔧 Apply security patches and updates regularly.",
            "🔧 Configure strong access controls and authentication."
        },
        ["spear-phishing"] = new List<string>
        {
            "🐟 Spear phishing targets specific individuals or groups.",
            "🐟 Be cautious of unsolicited requests for information.",
            "🐟 Verify the identity of the requester through official channels."
        },
        ["perfect-forward-secrecy"] = new List<string>
        {
            "🔒 Ensures that session keys are derived independently.",
            "🔒 Protects past communications even if long-term keys are compromised.",
            "🔒 Use protocols that support PFS, like TLS 1.3."
        },
        ["mitm-prevention"] = new List<string>
        {
            "🌐 Use HTTPS and SSL/TLS to encrypt communications.",
            "🌐 Implement mutual authentication to verify both parties.",
            "🌐 Regularly update and patch your systems."
        },
        ["ransomware-detailed"] = new List<string>
        {
            "💀 Back up data regularly using 3-2-1 strategy (3 copies, 2 media types, 1 offsite).",
            "💀 Use ransomware detection tools and monitor system behavior.",
            "💀 Never pay ransom demands as it encourages further attacks."
        },
        ["public-key-infrastructure"] = new List<string>
        {
            "🔑 Uses public and private keys for encryption and authentication.",
            "🔑 Certificates are issued by Certificate Authorities (CAs).",
            "🔑 Use PKI to secure communications and verify identities."
        },
        ["spoofing"] = new List<string>
        {
            "🚫 Use DNSSEC to protect against DNS spoofing.",
            "🚫 Implement email authentication protocols like SPF, DKIM, and DMARC.",
            "🚫 Regularly monitor and update your security configurations."
        },
        ["server-hacking-steps"] = new List<string>
        {
            "💻 Reconnaissance, scanning, gaining access, maintaining access, and covering tracks.",
            "💻 Implement strong access controls and monitor for unusual activity.",
            "💻 Regularly update and patch your systems."
        },
        ["sniffing-tools"] = new List<string>
        {
            "🔍 Use network sniffing tools like Wireshark for legitimate monitoring.",
            "🔍 Protect against sniffing by encrypting communications.",
            "🔍 Regularly update and patch your systems."
        },
        ["sql-injection"] = new List<string>
        {
            "🗄️ Always use parameterized queries instead of string concatenation.",
            "🗄️ Validate input data types and sanitize user inputs.",
            "🗄️ Implement least privilege database access for applications."
        },
        ["ddos"] = new List<string>
        {
            "💥 Distributed Denial of Service attacks overwhelm servers with traffic.",
            "💥 Use DDoS protection services and configure rate limiting.",
            "💥 Regularly monitor and update your security configurations."
        },
        ["arp-poisoning-prevention"] = new List<string>
        {
            "🌐 Use ARP inspection and dynamic ARP inspection (DAI).",
            "🌐 Regularly update and patch your systems.",
            "🌐 Monitor network traffic for unusual ARP activity."
        },
        ["proxy-firewall"] = new List<string>
        {
            "🔥 Network security system monitoring incoming/outgoing traffic.",
            "🔥 Configure rules to block unauthorized access while allowing legitimate traffic.",
            "🔥 Use both hardware (network) and software (endpoint) firewalls."
        },
        ["ssl-encryption"] = new List<string>
        {
            "🔒 Encrypts data transmitted over the internet.",
            "🔒 Use strong SSL/TLS protocols and ciphers.",
            "🔒 Regularly update and patch your systems."
        },
        ["penetration-testing"] = new List<string>
        {
            "🔍 Simulates attacks to identify vulnerabilities.",
            "🔍 Conduct regular penetration tests to assess security.",
            "🔍 Use the findings to improve your security posture."
        },
        ["diffie-hellman-vs-rsa"] = new List<string>
        {
            "🔑 Diffie-Hellman is used for key exchange, RSA for encryption/decryption.",
            "🔑 Both are asymmetric algorithms but serve different purposes.",
            "🔑 Use both to secure communications and data."
        },
        ["asymmetric-encryption-examples"] = new List<string>
        {
            "🔑 RSA, ECC, and ElGamal are common asymmetric encryption algorithms.",
            "🔑 Use strong key lengths and secure implementations.",
            "🔑 Regularly update and patch your systems."
        },
        ["vulnerability-vs-exploit"] = new List<string>
        {
            "💥 Vulnerabilities are weaknesses in systems, exploits take advantage of them.",
            "💥 Regularly update and patch your systems to close vulnerabilities.",
            "💥 Monitor for new vulnerabilities and exploits."
        },
        ["risk-vulnerability-threat"] = new List<string>
        {
            "💥 Risk is the likelihood and impact of a threat exploiting a vulnerability.",
            "💥 Vulnerabilities are weaknesses that can be exploited.",
            "💥 Threats are potential sources of harm."
        },
        ["phishing-prevention"] = new List<string>
        {
            "🐟 Verify sender identity by checking email addresses carefully.",
            "🐟 Avoid clicking links in unsolicited messages; type URLs manually.",
            "🐟 Use email filters and report phishing attempts to your provider."
        },
            // Add more topics here as needed...
        };

        private static readonly Random random = new Random();

        public static string GetResponse(string topic)
        {
            if (topicResponses.TryGetValue(topic.ToLower(), out var responses))
            {
                int index = random.Next(responses.Count);
                return responses[index];
            }
            else
            {
                return "I'm still learning about that topic. Please try another one related to cybersecurity.";
            }
        }
    }
}
