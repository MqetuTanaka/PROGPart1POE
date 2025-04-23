using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using NAudio.Wave;
using System;
using System.Threading;

// Encapsulation and Inheritance
public abstract class BotResponse
{
    public string Trigger { get; set; }
    public abstract string GetResponse();
}

public class GreetingResponse : BotResponse
{
    public string UserName { get; set; }

    public GreetingResponse(string userName)
    {
        Trigger = "greeting";
        UserName = userName;
    }

    public override string GetResponse()
    {
        return $"Welcome {UserName}! Let's discuss cybersecurity in a way that's easy to understand!";
    }
}

public class SecurityResponse : BotResponse
{
    public SecurityResponse(string trigger, string topic)
    {
        Trigger = trigger;
        Topic = topic;
    }

    public string Topic { get; set; }

    public override string GetResponse()
    {
        return Topic switch
        {
            "password" => "What: Strong passwords protect your accounts.\nWhy: Prevent unauthorized access.\nHow: Use 12+ characters with letters, numbers, and symbols.\nWhen: Change passwords regularly and after breaches.",
            "phishing" => "What: Phishing is fraudulent emails impersonating legitimate sources.\nWho: Targets anyone with online access.\nWhy: To steal personal information.\nHow: Verify sender addresses and avoid clicking suspicious links.",
            "malware" => "What: Malicious software that infects devices.\nTypes: Viruses, worms, ransomware, spyware.\nWhy: To cause damage or steal information.\nPrevention: Use antivirus software and avoid suspicious downloads.",
            "vpn" => "What: VPN creates a secure connection over public networks.\nWhy: Protects privacy and access geo-restricted content.\nWhen: Use on public Wi-Fi or accessing sensitive information.\nHow: Subscribe to a reputable VPN service and connect before browsing.",
            "two-factor" => "What: Two-factor authentication adds an extra security layer.\nWhy: Prevents account access even if passwords are compromised.\nHow: Combine something you know (password) with something you have (phone/code).\nWhen: Enable for all critical accounts.",
            "publicwifi" => "What: Public Wi-Fi is insecure and can expose your data.\nWhy: Traffic can be intercepted by attackers.\nHow: Use VPN, avoid sensitive transactions, and ensure sites use HTTPS.\nWhen: Anytime you connect to public wireless networks.",
            "updates" => "What: Software updates fix security vulnerabilities.\nWhy: Protects against newly discovered threats.\nWhen: Enable automatic updates for all devices and software.\nHow: Check for updates regularly and install promptly.",
            "encryption" => "What: Encryption converts data into coded information.\nWhy: Protects confidentiality and integrity.\nTypes: Symmetric and asymmetric encryption.\nHow: Use built-in encryption tools for files and communications.",
            "socialengineering" => "What: Social engineering manipulates people into revealing information.\nWho: Targets everyone, from individuals to employees.\nWhy: Bypasses technical security measures.\nPrevention: Educate users and verify requests through multiple channels.",
            "backup" => "What: Backups are copies of your data stored separately.\nWhy: Protects against data loss from hardware failure or attacks.\nHow: Use cloud storage and external drives.\nWhen: Regularly, following the 3-2-1 backup strategy (3 copies, 2 different media, 1 offsite).",
            "firewalls" => "What: Firewalls monitor and filter network traffic.\nWhy: Prevent unauthorized access to private networks.\nHow: Configure with proper rules and enable on all devices.\nWhen: Essential for any network-connected device.",
            "ransomware" => "What: Ransomware encrypts data and demands payment for decryption.\nWho: Targets individuals and organizations.\nWhy: To extort money through fear and urgency.\nPrevention: Regular backups, security software, and cautious email handling.",
            "securebrowsing" => "What: Secure browsing practices protect against web-based threats.\nHow: Use HTTPS, avoid suspicious sites, and keep browsers updated.\nWhen: Every time you access the internet.\nWhy: Prevents malware infections and data theft.",
            "credentials" => "What: Credentials are your login information.\nWhy: They grant access to your accounts and sensitive data.\nHow: Protect with strong passwords and two-factor authentication.\nWhen: Anytime you access online services.",
            "insiderthreats" => "What: Insider threats come from within an organization.\nWho: May involve employees, contractors, or partners.\nWhy: Disgruntled individuals or accidental exposures.\nMitigation: Limit access, monitor activity, and conduct security training.",
            "dataprivacy" => "What: Data privacy controls how your information is collected and used.\nWhy: Protects against identity theft and unauthorized surveillance.\nHow: Read privacy policies, use privacy-focused services, and minimize data sharing.\nWhen: Anytime you interact with digital services.",
            "passwordmanagers" => "What: Password managers securely store and generate passwords.\nWhy: Eliminates password reuse and weak passwords.\nHow: Choose a reputable manager and enable two-factor authentication.\nWhen: Ideal for anyone with multiple online accounts.",
            "zerotrust" => "What: Zero Trust assumes no one is trustworthy by default.\nWhy: Minimizes attack surfaces and contains breaches.\nHow: Verify every access request and continuously monitor.\nWhen: Essential for modern network security architectures.",
            "botnets" => "What: Botnets are networks of infected devices controlled remotely.\nWhy: Used for DDoS attacks, spam distribution, and data theft.\nHow: Protect with firewalls, antivirus software, and system updates.\nWhen: Any connected device could potentially be recruited into a botnet.",
            "mobilesecurity" => "What: Mobile security protects your smartphone and data.\nWhy: Mobile devices are targets for attackers.\nHow: Use screen locks, app permissions, and avoid sideloading.\nWhen: Essential for any smartphone user.",
            "physicalsecurity" => "What: Physical security protects devices from theft and tampering.\nWhy: Stolen devices can lead to data breaches.\nHow: Lock devices, shred documents, and restrict access.\nWhen: Important for both personal and workplace environments.",
            "securityawareness" => "What: Security awareness is understanding potential threats.\nWhy: Human error is a leading cause of breaches.\nHow: Regular training and staying informed about common attacks.\nWhen: Ongoing process for all technology users.",
            "threatdetection" => "What: Threat detection identifies potential security incidents.\nWhy: Early detection minimizes damage.\nHow: Use IDS/IPS systems and monitor logs.\nWhen: Continuous monitoring is essential for network security.",
            "incidentresponse" => "What: Incident response is your plan for security breaches.\nWhy: Reduces recovery time and damage.\nHow: Develop a plan with detection, containment, and recovery steps.\nWhen: Before, during, and after security incidents.",
            "common-cyberattacks" => "What: Common cyberattacks include phishing, malware, ransomware, and social engineering.\nWho: Targets everyone from individuals to large organizations.\nWhy: To steal information, cause disruption, or extort money.\nPrevention: Education, updates, and security software.",
            "elements-of-cybersecurity" => "What: Elements include application security, information security, network security, disaster recovery, operational security, and end-user education.\nWhy: Comprehensive protection requires multiple layers.\nHow: Implement policies and technologies for each element.\nWhen: All elements should be integrated into your security strategy.",
            "dns" => "What: DNS translates domain names to IP addresses.\nWhy: Allows users to access sites using memorable names.\nHow: Your device queries DNS servers to find IP addresses.\nWhen: Every time you visit a website or use internet services.",
            "firewall-detailed" => "What: A firewall monitors and filters network traffic.\nWhy: Prevents unauthorized access and malicious traffic.\nHow: Configures rules to allow or block connections.\nWhen: Essential for any network-connected device.",
            "vpn-detailed" => "What: VPN creates a secure tunnel over public networks.\nWhy: Protects privacy and accesses restricted content.\nHow: Connect to a VPN server before browsing.\nWhen: Using public Wi-Fi or accessing geo-blocked services.",
            "malware-sources" => "What: Malware sources include suspicious downloads, email attachments, and malicious websites.\nTypes: Worms, spyware, ransomware, viruses, Trojans, adware.\nWhy: To infect systems and steal information.\nPrevention: Antivirus software, cautious browsing, and email filtering.",
            "email-work" => "What: Email sends messages between users over the internet.\nHow: Uses SMTP, POP3, and IMAP protocols.\nWhen: Anytime you send or receive emails.\nWhy: Convenient communication but requires security precautions.",
            "active-passive-attacks" => "What: Active attacks modify data, while passive attacks monitor traffic.\nWho: Attackers seeking different outcomes.\nWhy: Active aims to disrupt, passive to eavesdrop.\nDetection: Active may be noticed, passive is harder to detect.",
            "social-engineering-detailed" => "What: Social engineering manipulates people into revealing information.\nWho: Targets everyone, especially those with access to valuable data.\nWhy: Bypasses technical security through psychological tactics.\nPrevention: Education, verification procedures, and skepticism of urgent requests.",
            "hackers-types" => "Who: White hat hackers work ethically to improve security.\nBlack hat hackers exploit systems maliciously.\nWhy: White hats prevent attacks, black hats cause damage.\nHow: Both use similar techniques but with different intentions.",
            "encryption-decryption" => "What: Encryption converts data to ciphertext, decryption restores it.\nWhy: Protects confidentiality and integrity.\nHow: Uses algorithms and cryptographic keys.\nWhen: Essential for secure communications and data storage.",
            "plaintext-cleartext" => "What: Plaintext is unencrypted data, cleartext is data never intended for encryption.\nWhy: Plaintext may become encrypted, cleartext remains open.\nHow: Plaintext can be encrypted, cleartext cannot.\nWhen: Plaintext during/after encryption processes, cleartext always readable.",
            "block-cipher" => "What: Block cipher encrypts data in fixed-size blocks.\nWhy: Provides strong security for bulk data.\nHow: Uses same key for each block, modes like ECB and CBC.\nWhen: Suitable for encrypting large amounts of data.",
            "cia-triangle" => "What: CIA stands for Confidentiality, Integrity, and Availability.\nWhy: Fundamental principles of information security.\nHow: Implemented through various security controls.\nWhen: Basis for all security policies and practices.",
            "three-way-handshake" => "What: Three-way handshake establishes TCP connections.\nSteps: SYN, SYN-ACK, ACK.\nWhy: Ensures both parties are ready for communication.\nWhen: Every time a TCP connection is initiated.",
            "identity-theft-prevention" => "What: Identity theft is unauthorized use of personal information.\nWhy: Can lead to financial loss and reputational damage.\nHow: Strong passwords, two-factor authentication, monitoring accounts.\nWhen: Ongoing vigilance is required.",
            "hashing-functions" => "What: Hashing converts data to fixed-size values.\nWhy: Used for integrity checks and password storage.\nTypes: Division, mid-square, folding, multiplication.\nWhen: Storing passwords, indexing data, verifying downloads.",
            "two-factor-authentication" => "What: 2FA requires two verification methods.\nWhy: Adds security layer beyond passwords.\nHow: Combine password with code from app, SMS, or hardware token.\nWhen: Enable for all critical accounts.",
            "xss" => "What: XSS is cross-site scripting vulnerabilities.\nWhy: Allows attackers to execute scripts in users' browsers.\nHow: Input validation, output encoding, proper headers.\nWhen: Any web application handling user input.",
            "shoulder-surfing" => "What: Shoulder surfing is observing sensitive information.\nWhere: Public places like cafes or airports.\nWhy: To steal passwords or personal data.\nPrevention: Privacy screens, awareness of surroundings.",
            "hashing-vs-encryption" => "What: Hashing creates fixed digests, encryption transforms data.\nWhy: Hashing for integrity, encryption for confidentiality.\nHow: Hashing is one-way, encryption is reversible with keys.\nWhen: Hashing for passwords, encryption for sensitive communications.",
            "information-security-vs-assurance" => "What: Information security focuses on protection, assurance on risk management.\nWhy: Security prevents breaches, assurance ensures continuity.\nHow: Security uses technical controls, assurance includes planning.\nWhen: Both integrated into comprehensive security strategy.",
            "https-vs-ssl" => "What: HTTPS is secure HTTP using SSL/TLS.\nWhy: Encrypts data between clients and servers.\nHow: Websites use certificates issued by trusted authorities.\nWhen: Anytime sensitive data is transmitted online.",
            "system-hardening" => "What: System hardening reduces attack surface.\nWhy: Minimizes vulnerabilities and prevents exploits.\nHow: Remove unnecessary software, update systems, configure firewalls.\nWhen: Implement during setup and regularly thereafter.",
            "spear-phishing" => "What: Spear phishing targets specific individuals.\nWhy: Higher success rate with personalized information.\nHow: Research targets to craft convincing messages.\nPrevention: Education, email filtering, verification procedures.",
            "perfect-forward-secrecy" => "What: PFS ensures session keys aren't derived from previous ones.\nWhy: Compromising one key doesn't affect others.\nHow: Uses ephemeral key exchanges.\nWhen: Critical for secure communications like messaging apps.",
            "mitm-prevention" => "What: MITM attacks intercept communications.\nWhy: To steal information or alter messages.\nHow: Use encryption, VPNs, validate certificates.\nWhen: Anytime using networks not under your control.",
            "ransomware-detailed" => "What: Ransomware encrypts data for monetary ransom.\nWhy: Profit motive drives cybercriminals.\nHow: Delivered via phishing, exploits, or vulnerable software.\nPrevention: Backups, updates, security awareness.",
            "public-key-infrastructure" => "What: PKI manages digital certificates and keys.\nWhy: Establishes trust in digital communications.\nHow: Uses certificate authorities and registration authorities.\nWhen: Essential for secure internet communications.",
            "spoofing" => "What: Spoofing falsifies digital identities.\nTypes: IP, email, ARP spoofing.\nWhy: Impersonate legitimate entities to gain trust.\nPrevention: Authentication protocols, encryption, network monitoring.",
            "server-hacking-steps" => "What: Server hacking involves multiple stages.\nSteps: Reconnaissance, scanning, gaining access, maintaining access, covering tracks.\nWhy: To steal data, disrupt services, or cause damage.\nPrevention: Regular audits, updates, intrusion detection systems.",
            "sniffing-tools" => "What: Sniffing tools capture and analyze network traffic.\nExamples: Wireshark, tcpdump, NetworkMiner.\nWhy: Used for monitoring, debugging, or malicious eavesdropping.\nHow: Capture packets from network interfaces.\nWhen: Network troubleshooting or security analysis.",
            "sql-injection" => "What: SQL injection attacks insert malicious queries.\nWhy: To manipulate databases or extract information.\nHow: Input validation, parameterized queries, least privilege.\nWhen: Any application with user-input database queries.",
            "ddos" => "What: DDoS attacks overwhelm targets with traffic.\nWhy: To make services unavailable to users.\nHow: Botnets of infected devices generate excessive requests.\nMitigation: Traffic filtering, cloud-based protection, over-provisioning.",
            "arp-poisoning-prevention" => "What: ARP poisoning links incorrect MAC addresses to IP addresses.\nWhy: Allows attackers to intercept or alter traffic.\nHow: Static ARP entries, Dynamic ARP Inspection, network segmentation.\nWhen: Essential for LAN security.",
            "proxy-firewall" => "What: Proxy firewall mediates between clients and servers.\nWhy: Hides client IP addresses and filters content.\nHow: Requests pass through proxy server for inspection.\nWhen: Adds layer of abstraction between internal and external networks.",
            "ssl-encryption" => "What: SSL encrypts data between clients and servers.\nWhy: Protects against eavesdropping and man-in-the-middle attacks.\nHow: Uses public-key cryptography for handshakes, symmetric encryption for data.\nWhen: Anytime sensitive data is transmitted online.",
            "penetration-testing" => "What: Penetration testing simulates cyber attacks.\nWhy: Identifies vulnerabilities before malicious actors.\nHow: Authorized attempts to bypass security measures.\nWhen: Regularly, especially after significant system changes.",
            "public-wifi-risks" => "What: Public Wi-Fi risks include eavesdropping and malicious access points.\nWhy: Traffic is often unencrypted and accessible to others.\nHow: Use VPN, validate certificates, avoid sensitive transactions.\nWhen: Anytime connecting to public wireless networks.",
            "diffie-hellman-vs-rsa" => "What: Diffie-Hellman exchanges keys, RSA encrypts data.\nWhy: DH for key agreement, RSA for encryption/decryption.\nHow: DH uses modular exponentiation, RSA uses factoring problems.\nWhen: DH for secure key exchange, RSA for digital signatures and encryption.",
            "asymmetric-encryption-examples" => "What: Asymmetric encryption uses key pairs.\nExamples: RSA, ECC, ElGamal, Diffie-Hellman.\nWhy: Enables secure communication without sharing keys.\nHow: Public key encrypts, private key decrypts.\nWhen: Email encryption, secure websites, digital signatures.",
            "vulnerability-vs-exploit" => "What: Vulnerability is a weakness, exploit is malicious code.\nWhy: Vulnerabilities create opportunities for exploits.\nHow: Patch management reduces vulnerabilities, intrusion detection finds exploits.\nWhen: Continuous monitoring and updating required.",
            "risk-vulnerability-threat" => "What: Risk is potential loss, vulnerability is weakness, threat is potential danger.\nWhy: Understanding these helps prioritize security efforts.\nHow: Risk = Threat × Vulnerability × Impact.\nWhen: Fundamental to risk assessment processes.",
            "phishing-prevention" => "What: Phishing prevention protects against deceptive emails.\nHow: Verify sender addresses, avoid clicking links, use email filtering.\nWhen: Every time you receive unsolicited messages.\nWhy: Phishing is a leading cause of data breaches.",
            "forward-secrecy" => "What: Forward secrecy protects past sessions if keys are compromised.\nWhy: Ensures previous communications remain private.\nHow: Uses ephemeral keys for each session.\nWhen: Critical for protecting sensitive conversations.",
            _ => "I can help with various cybersecurity topics. Just ask your question!"
        };
    }
}

// New GeneralResponse class for conversational questions
public class GeneralResponse : BotResponse
{
    public string ResponseText { get; set; }

    public GeneralResponse(string trigger, string responseText)
    {
        Trigger = trigger;
        ResponseText = responseText;
    }

    public override string GetResponse()
    {
        return ResponseText;
    }
}

// Main Chatbot Class
public class CyberSecurityBot
{
    private List<BotResponse> responses = new List<BotResponse>();
    private List<string> chatHistory = new List<string>();
    private string userName;

    // Events and Delegates
    public delegate void UserInputReceivedEvent(string input);
    public event UserInputReceivedEvent OnUserInputReceived;

    private void PlaySound(string filePath)
    {
        try
        {
            Console.WriteLine($"Attempting to play sound from: {filePath}");

            using (var audioFile = new AudioFileReader(filePath))
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(audioFile);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine("Sound played successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The specified audio file was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audio playback error: {ex.Message}");
        }
    }

    public CyberSecurityBot()
    {
        // Initialize responses using polymorphism
        responses.Add(new GreetingResponse("Guest"));

        string[] topics = new string[]
        {
            "password", "phishing", "malware", "vpn", "two-factor",
            "publicwifi", "updates", "encryption", "socialengineering", "backup",
            "firewalls", "ransomware", "securebrowsing", "credentials", "insiderthreats",
            "dataprivacy", "passwordmanagers", "zerotrust", "botnets", "mobilesecurity",
            "physicalsecurity", "securityawareness", "threatdetection", "incidentresponse",
            "common-cyberattacks", "elements-of-cybersecurity", "dns", "firewall-detailed", "vpn-detailed",
            "malware-sources", "email-work", "active-passive-attacks", "social-engineering-detailed",
            "hackers-types", "encryption-decryption", "plaintext-cleartext", "block-cipher",
            "cia-triangle", "three-way-handshake", "identity-theft-prevention", "hashing-functions",
            "two-factor-authentication", "xss", "shoulder-surfing", "hashing-vs-encryption",
            "information-security-vs-assurance", "https-vs-ssl", "system-hardening", "spear-phishing",
            "perfect-forward-secrecy", "mitm-prevention", "ransomware-detailed", "public-key-infrastructure",
            "spoofing", "server-hacking-steps", "sniffing-tools", "sql-injection", "ddos",
            "arp-poisoning-prevention", "proxy-firewall", "ssl-encryption", "penetration-testing",
            "public-wifi-risks", "diffie-hellman-vs-rsa", "asymmetric-encryption-examples",
            "vulnerability-vs-exploit", "risk-vulnerability-threat", "phishing-prevention", "forward-secrecy"
        };

        foreach (var topic in topics)
        {
            responses.Add(new SecurityResponse(topic, topic));
        }

        // Add conversational responses
        responses.Add(new GeneralResponse("how are you", "I'm just a bot, but I'm functioning optimally! How can I help protect your digital life today?"));
        responses.Add(new GeneralResponse("whats your purpose", "My purpose is to make cybersecurity approachable and understandable. I want to help you protect your digital life without the jargon!"));
        responses.Add(new GeneralResponse("what can i ask you about", "You can ask me about everyday security topics like protecting your home network, creating strong passwords, spotting phishing emails, or securing your smartphone. Type 'help' for a full list!"));
        responses.Add(new GeneralResponse("help me secure my home network", "Great question! Start by changing your router's default password, enable WPA3 encryption, update firmware regularly, and consider creating a guest network for visitors. Want more details?"));
        responses.Add(new GeneralResponse("how to spot phishing emails", "Phishing emails often create urgency or fear. Check the sender's email address carefully (not just the display name), hover over links to see where they lead, and never share sensitive info unless you're certain of the site's legitimacy."));
        responses.Add(new GeneralResponse("protect my smartphone", "Smartphone security basics: Use a strong PIN/pattern, enable remote wipe, be cautious with app permissions, avoid sideloading apps, and keep your OS updated. Treat your phone like the treasure chest of personal data that it is!"));
        responses.Add(new GeneralResponse("keep my family safe online", "Family online safety: Set up parental controls, educate about privacy settings, use secure Wi-Fi, discuss the importance of strong passwords, and establish rules about sharing personal information online. Want specific tools or strategies?"));
        responses.Add(new GeneralResponse("what is a security breach", "A security breach is when unauthorized people access your data. It's like someone breaking into your house but digitally. Common signs include unusual login activity, password resets you didn't request, or strange charges on accounts. Prevention is key!"));
        responses.Add(new GeneralResponse("how to recover from a hack", "First, stay calm. Change affected passwords, enable two-factor authentication, scan for malware, update software, and monitor accounts for suspicious activity. If it's serious, consider contacting a security professional or your bank."));

        // Lambda expression for event handling
        OnUserInputReceived += input =>
        {
            chatHistory.Add($"You: {input}");
        };
    }

    public void Start()
    {
        try
        {
            // Clear console and set initial window size
            Console.Clear();
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;

            // Play welcome sound
            this.PlaySound("Security Bot.wav");

            // Display ASCII art
            DisplayAsciiArt();

            // Get user name
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();

            // Update greeting response with user's name
            var greeting = responses.First(r => r is GreetingResponse) as GreetingResponse;
            greeting.UserName = userName;

            // Main interaction loop
            while (true)
            {
                DisplayChatWindow();

                Console.Write("\nAsk me something (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                // Trigger event
                OnUserInputReceived?.Invoke(input);

                if (input.ToLower() == "exit") break;

                ProcessUserInput(input);
            }
        }
        catch (Exception ex)
        {
            // Structured exception handling
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {ex.Message}");
            Console.ResetColor();
        }
    }

    private void ProcessUserInput(string input)
    {
        try
        {
            // Normalize input: trim, lowercase, remove punctuation
            string normalizedInput = input.Trim().ToLower();
            normalizedInput = new string(normalizedInput.Where(c => char.IsLetterOrDigit(c) || c == ' ').ToArray());

            // Check for help command
            if (normalizedInput == "help")
            {
                chatHistory.Add("Bot: Here are some topics I can help with:");
                chatHistory.Add("Bot: - Common Cyberattacks");
                chatHistory.Add("Bot: - Elements of Cybersecurity");
                chatHistory.Add("Bot: - DNS, Firewall, VPN");
                chatHistory.Add("Bot: - Malware, Phishing, Ransomware");
                chatHistory.Add("Bot: - Encryption, Hashing, Two-factor Authentication");
                chatHistory.Add("Bot: - And many more! Just ask your question!");
                return;
            }

            // Use LINQ with generics for efficient searching
            var matchedResponse = responses.FirstOrDefault(r =>
                r.Trigger.Equals(normalizedInput, StringComparison.OrdinalIgnoreCase));

            if (matchedResponse != null)
            {
                chatHistory.Add($"Bot: {matchedResponse.GetResponse()}");
                DisplayTypingEffect();
            }
            else
            {
                // Try keyword matching for more flexible responses
                var keywordMatch = responses.FirstOrDefault(r =>
                    r.Trigger.Split('-').Any(keyword => normalizedInput.Contains(keyword)) ||
                    r.Trigger.Contains(normalizedInput));

                if (keywordMatch != null)
                {
                    chatHistory.Add($"Bot: {keywordMatch.GetResponse()}");
                    DisplayTypingEffect();
                }
                else
                {
                    chatHistory.Add("Bot: I didn't understand. Try asking about passwords, phishing, securing your home network, protecting your smartphone, or family online safety. Type 'help' for options.");
                }
            }
        }
        catch (Exception ex)
        {
            chatHistory.Add($"\nError processing input: {ex.Message}");
        }
    }

    private void DisplayChatWindow()
    {
        Console.Clear();

        // Draw top border
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine("CYBERSECURITY AWARENESS BOT");
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.ResetColor();
        Console.WriteLine();

        // Display chat history
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var message in chatHistory.TakeLast(10))
        {
            Console.WriteLine(message);
        }
        Console.ResetColor();
    }

    private void DisplayTypingEffect()
    {
        Console.Write("\nBot is thinking...");
        Thread.Sleep(1000);
        Console.Write("\r{0," + Console.WindowWidth + "}", ""); // Clear line
    }

    private void DisplayAsciiArt()
    {
        string filePath = "Security Bot.wav";

        string asciiArt = @"
                                              ░▒░░▒░                                                  
                                              ░░   ▒░                                               
                                       ░▒▒░░  ░░▒▒▒░   ░▒▒░░                                      
                                      ░░  ░▒░  ░▒▒░   ░░  ░▒░                                       
                                      ░▒░░░▒   ░▒▒░   ░▒░░░░                                      
                                        ▒▒░     ▒▒░     ▒▒░                                         
                                        ▒▒░    ░▒▒░     ▒▒░                                         
                                        ▒▒░    ░▒▒░     ▒▒░                                         
                                        ▒▒░▒▒▒▒▒▒▒▒▒▒▒▒░▒▒░                                         
                                    ░░▒▒▒▒▒▒▒▒░    ░░▒▒▒▒▒▒▒▒░                                      

                                    ▒▒▒▒░░   ░▒▒▒▒▒▒▒░   ░░▒▒▒░                                     
                       ░▒░░▒░░░░░░░░▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒░░░░░░░▒░░░▒                         
                       ▒░  ░▒▒▒▒▒▒▒▒▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒▒▒▒▒▒▒▒▒   ▒░                        
                        ░▒▒░        ▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒       ░▒▒▒░                          
                                   ░▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒                                     
                   ░▒▒▒▒           ░▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒           ░▒▒▒▒░                    
                  ░▒░  ░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░  ░░                    
                   ░▒░░▒░░░ ░░ ░░ ░░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ▒▒▒░░ ░░ ░░ ░░░▒░░▒░                    
                                   ░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ ░▒▒                                     
                        ░░▒░       ░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░ ░▒▒       ░░▒░░                          
                       ▒░  ░▒▒▒▒▒▒▒▒▒▒▒ ░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ ░▒▒▒▒▒▒▒▒▒▒▒   ▒░                        
                       ░░░░░░░░░░░░░░▒▒▒  ░▒▒▒▒▒▒▒▒▒▒▒▒▒░ ░▒▒▒░░░░░░░░▒░ ░▒░                        
                         ░░           ▒▒▒▒░  ░▒▒▒▒▒▒░   ▒▒▒▒░          ░░░                          

                                       ░▒▒▒▒▒▒░  ░  ░▒▒▒▒▒░                                         
                                        ▒▒░░▒▒▒▒▒▒▒▒▒▒▒░▒▒░                                         
                                        ▒▒░   ░▒▒▒▒░    ▒▒░                                         
                                        ▒▒░     ▒▒░     ▒▒░                                         
                                       ░▒▒░    ░▒▒░    ░▒▒░                                         
                                      ░▒  ░▒░  ░▒▒░   ░▒  ░▒                                      
                                      ░▒░ ░▒░   ▒▒░   ░▒  ░▒                                      
                                        ░░░   ░▒░░░▒    ░░░                                         
                                              ░░   ▒░                                               
                                               ░▒▒▒░                                                

                      ░▒▒░▒░ ▒░▒▒░ ▒▒▒░░▒▒░ ░▒▒░░▒▒▒ ░▒▒░░░ ░░░▒▒░ ▒░▒▒▒▒▒ ░▒                       
                     ░▓    ▓▓░░▓▒▓ ▓▒▒░▒▒░▓░▒▓▒░▒▓▒░▒▒   ▒▒ ▒▒▒▒░▓░▓░ ▓░ ░▓▓                       
                      ▓▓▓▓ ░▓ ░▓▒▓▒▓▒▒▒▒▒░▓ ▓▓▓▒▒▓▒▒░▓▓▓▓░▓▒▓░▒▒▒▓ ▓░ ▓   ▒░   
";
        Console.WriteLine(asciiArt);
        Console.WriteLine();
    }
}

// Program Entry Point
class Program
{
    static void Main(string[] args)
    {
        var bot = new CyberSecurityBot();
        bot.Start();
    }
}