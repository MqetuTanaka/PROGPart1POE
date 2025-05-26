using NAudio.Wave;
using System;
using System.Threading;
using CyberSecurityBotApp.Models;

namespace CyberSecurityBotApp
{
    public class CyberSecurityBot
    {
        private List<BotResponse> responses = new List<BotResponse>();
        private string userName;
        private List<string> chatHistory = new List<string>();
        private Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private string lastTopic;

        public event Action<string> OnUserInputReceived;

        public CyberSecurityBot()
        {
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            responses.Add(new GreetingResponse("Guest"));

            string[] topics = {
            "password", "phishing", "privacy", "scam", "malware", "vpn", "two-factor",
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
                SecurityResponse securityResponse = new SecurityResponse(topic, topic)
                {
                    ExtendedResponse = GetExtendedResponseForTopic(topic)
                };

                if (topic == "phishing")
                {
                    securityResponse.AddRandomResponse("Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.");
                    securityResponse.AddRandomResponse("Always check the sender's email address carefully. Scammers can create addresses that look very similar to legitimate ones.");
                    securityResponse.AddRandomResponse("A tricky fishing hook that tries to catch your secrets.");
                }
                if (topic == "password")
                {
                    securityResponse.AddRandomResponse("A secret word only you know to open your favorite game.");
                    securityResponse.AddRandomResponse("A magical key that keeps your toys safe from strangers.");
                    securityResponse.AddRandomResponse("A string of characters used to authenticate access to a system or account.");
                }
                if (topic == "privacy")
                {
                    securityResponse.AddRandomResponse("A secret hideout where only you decide who comes in.");
                    securityResponse.AddRandomResponse("Keeping your special things only for yourself.");
                    securityResponse.AddRandomResponse("The state of being free from public attention or unauthorized access to personal information.");
                }
                if (topic == "scam")
                {
                    securityResponse.AddRandomResponse("A dishonest scheme designed to deceive and defraud someone.");
                    securityResponse.AddRandomResponse("A sneaky trick that takes something from you unfairly.");
                    securityResponse.AddRandomResponse("A pretend promise that makes you lose instead of win.");
                }
                if (topic == "malware")
                {
                    securityResponse.AddRandomResponse("Bad bugs that make computers sick and slow.");
                    securityResponse.AddRandomResponse("Tiny monsters hiding in your tablet, messing things up.");
                    securityResponse.AddRandomResponse("Software designed to disrupt, damage, or gain unauthorized access to a computer system.");
                }
                if (topic == "vpn")
                {
                    securityResponse.AddRandomResponse("A virtual private network that encrypts internet traffic and protects online identity");
                    securityResponse.AddRandomResponse("A magic cloak that makes your internet journey invisible.");
                    securityResponse.AddRandomResponse("A tunnel that hides you while you explore online.");
                }
                if (topic == "two factor")
                {
                    securityResponse.AddRandomResponse("A security process requiring two different forms of authentication to verify identity.");
                    securityResponse.AddRandomResponse("Two locks to keep your treasure chest extra safe.");
                    securityResponse.AddRandomResponse("An extra secret step to make sure only you can get in.");
                }
                if (topic == "public wifi")
                {
                    securityResponse.AddRandomResponse("A playground where everyone can play, but some might peek.");
                    securityResponse.AddRandomResponse("A giant open door where strangers can see inside.");
                    securityResponse.AddRandomResponse("A wireless internet connection available in public places, often unsecured.");
                }
                if (topic == "updates")
                {
                    securityResponse.AddRandomResponse("Improvements or fixes applied to software to enhance performance and security.");
                    securityResponse.AddRandomResponse("Fixes that make your apps smarter and stronger.");
                    securityResponse.AddRandomResponse("A power-up that makes your favorite game even better.");
                }
                if (topic == "encryption")
                {
                    securityResponse.AddRandomResponse("The process of converting data into a coded format to prevent unauthorized access.");
                    securityResponse.AddRandomResponse("Secret codes that scramble messages to keep them safe.");
                    securityResponse.AddRandomResponse("A puzzle that only the right person can solve.");
                }
                if (topic == "joke")
                {
                    securityResponse.AddRandomResponse("Why did the computer go to therapy? Because it had too many cookies!🍪😂");
                    securityResponse.AddRandomResponse("Why do cyber criminals love old computers? Because they have so many Windows of opportunity! 🏠💻");
                }
                responses.Add(securityResponse);
            }

            // Add conversational responses
            responses.Add(new GeneralResponse("how are you", "I'm just a bot, but I'm functioning optimally! How can I help protect your digital life today?"));
            responses.Add(new GeneralResponse("hi", "Hello! How are you?"));
            responses.Add(new GeneralResponse("im okay", "Great, How can i help you?"));
            responses.Add(new GeneralResponse("thank you", "I'm glad to help you anytime."));
            responses.Add(new GeneralResponse("purpose", "My purpose is to make cybersecurity approachable and understandable.", new List<string> { "purpose", "goal", "objective", "what are you for" }));
            responses.Add(new GeneralResponse("what can i ask you about", "You can ask me about everyday security topics like protecting your home network, creating strong passwords, spotting phishing emails, or securing your smartphone. Type 'help' for a full list!"));
            responses.Add(new GeneralResponse("help me secure my home network", "Great! Start by changing your router's default password, enable WPA3 encryption, update firmware regularly, and consider creating a guest network for visitors. Want more details?"));
            responses.Add(new GeneralResponse("how to spot phishing emails", "Phishing emails often create urgency or fear. Check the sender's email address carefully (not just the display name), hover over links to see where they lead, and never share sensitive info unless you're certain of the site's legitimacy."));
            responses.Add(new GeneralResponse("protect my smartphone", "Smartphone security basics: Use a strong PIN/pattern, enable remote wipe, be cautious with app permissions, avoid sideloading apps, and keep your OS updated. Treat your phone like the treasure chest of personal data that it is!"));
            responses.Add(new GeneralResponse("keep my family safe online", "Family online safety: Set up parental controls, educate about privacy settings, use secure Wi-Fi, discuss the importance of strong passwords, and establish rules about sharing personal information online. Want specific tools or strategies?"));
            responses.Add(new GeneralResponse("what is a security breach", "A security breach is when unauthorized people access your data. It's like someone breaking into your house but digitally. Common signs include unusual login activity, password resets you didn't request, or strange charges on accounts. Prevention is key!"));
            responses.Add(new GeneralResponse("how to recover from a hack", "First, stay calm. Change affected passwords, enable two-factor authentication, scan for malware, update software, and monitor accounts for suspicious activity. If it's serious, consider contacting a security professional or your bank."));
        }

        private string GetExtendedResponseForTopic(string topic)
        {
            return topic switch
            {
                "password" => "Additional information: Consider using a password manager to keep track of your passwords. Avoid using common words or phrases, and never reuse passwords across different sites.",
                "phishing" => "Additional information: Be especially cautious of emails that create a sense of urgency or threaten negative consequences if you don't act quickly. Legitimate organizations rarely use this tactic.",
                "privacy" => "Additional information: Regularly review the privacy settings of your online accounts. Be cautious about sharing personal information online.",
                "scam" => "Additional information: Be skeptical of unsolicited messages or calls asking for personal information or financial details. Verify the legitimacy of requests through official channels.",
                "malware" => "Additional information: Keep your software updated to protect against vulnerabilities. Use reputable antivirus software and avoid clicking on suspicious links or downloading unknown files.",
                "vpn" => "Additional information: Use a VPN to encrypt your internet traffic and protect your privacy, especially on public Wi-Fi networks.",
                "two-factor" => "Additional information: Enable two-factor authentication for added security. This requires a second form of verification in addition to your password.",
                "publicwifi" => "Additional information: Avoid accessing sensitive information on public Wi-Fi. Use a VPN to encrypt your data if you need to connect to public networks.",
                "updates" => "Additional information: Keep your operating system and applications updated to protect against security vulnerabilities.",
                "encryption" => "Additional information: Use encryption for sensitive data both in transit and at rest. Look for services that offer end-to-end encryption.",
                "socialengineering" => "Additional information: Be aware of social engineering attacks where attackers manipulate individuals into divulging confidential information.",
                "backup" => "Additional information: Regularly back up your important data to an external drive or cloud storage. Test your backups to ensure they can be restored.",
                "firewalls" => "Additional information: Enable and properly configure firewalls to monitor and control incoming and outgoing network traffic.",
                "ransomware" => "Additional information: Protect against ransomware by keeping software updated, using backups, and being cautious of suspicious emails and downloads.",
                "securebrowsing" => "Additional information: Use secure browsing practices such as checking for HTTPS in URLs and avoiding clicking on unknown links.",
                "credentials" => "Additional information: Never share your passwords or credentials with anyone. Use strong, unique passwords for each account.",
                "insiderthreats" => "Additional information: Implement strict access controls and monitor user activity to mitigate insider threats.",
                "dataprivacy" => "Additional information: Understand and exercise your data privacy rights. Be selective about the information you share online.",
                "passwordmanagers" => "Additional information: Use a reputable password manager to generate and store strong, unique passwords for all your accounts.",
                "zerotrust" => "Additional information: Adopt a Zero Trust security model where no entity, inside or outside the network, is trusted by default.",
                "botnets" => "Additional information: Protect your devices from botnets by keeping software updated, using strong passwords, and avoiding suspicious downloads.",
                "mobilesecurity" => "Additional information: Secure your mobile devices with strong PINs, enable remote wipe, and be cautious with app permissions.",
                "physicalsecurity" => "Additional information: Implement physical security measures such as locking devices, using strong authentication methods, and controlling access to sensitive areas.",
                "securityawareness" => "Additional information: Stay informed about cybersecurity threats and best practices through training and reliable resources.",
                "threatdetection" => "Additional information: Use security tools like antivirus software, firewalls, and intrusion detection systems to identify and respond to threats.",
                "incidentresponse" => "Additional information: Develop and regularly update an incident response plan to ensure quick and effective action during a security breach.",
                "common-cyberattacks" => "Additional information: Learn about common cyberattacks like phishing, malware, and ransomware to recognize and avoid them.",
                "elements-of-cybersecurity" => "Additional information: Cybersecurity involves multiple elements including confidentiality, integrity, availability, authentication, and non-repudiation.",
                "dns" => "Additional information: Understand how DNS works and consider using DNS security extensions like DNSSEC to prevent spoofing attacks.",
                "firewall-detailed" => "Additional information: Configure firewalls with least-privilege principles, allowing only necessary traffic and regularly reviewing rules.",
                "vpn-detailed" => "Additional information: Choose a reputable VPN service with strong encryption and a no-logs policy. Configure it to use secure protocols like OpenVPN or WireGuard.",
                "malware-sources" => "Additional information: Be cautious of common malware sources such as torrent sites, file-sharing platforms, and suspicious email attachments.",
                "email-work" => "Additional information: Use separate email accounts for different purposes and enable spam filtering to reduce the risk of phishing attacks.",
                "active-passive-attacks" => "Additional information: Deploy intrusion detection and prevention systems to monitor for both active and passive attacks.",
                "social-engineering-detailed" => "Additional information: Create a security-aware culture within organizations, encouraging employees to verify requests for information.",
                "hackers-types" => "Additional information: Understand different types of hackers, including white hat, black hat, and gray hat hackers, and their motivations.",
                "encryption-decryption" => "Additional information: Modern encryption algorithms like AES are secure for most applications. Proper key management is essential for encryption security.",
                "plaintext-cleartext" => "Additional information: Never store sensitive data in plaintext. Use secure hashing algorithms for passwords and encrypt data at rest and in transit.",
                "block-cipher" => "Additional information: Common block cipher modes include CBC, CTR, and GCM, each with different security and performance characteristics.",
                "cia-triangle" => "Additional information: The CIA triad consists of Confidentiality, Integrity, and Availability, forming the core principles of information security.",
                "three-way-handshake" => "Additional information: Protect against TCP SYN flood attacks by implementing proper TCP stack hardening and using firewalls.",
                "identity-theft-prevention" => "Additional information: Freeze your credit reports and regularly review them for suspicious activity to prevent identity theft.",
                "hashing-functions" => "Additional information: Cryptographic hashing functions are deterministic and produce a fixed-size output. Modern secure hashing algorithms include SHA-256 and SHA-3.",
                "two-factor-authentication" => "Additional information: Time-based One-Time Passwords (TOTP) are commonly used for two-factor authentication, providing an extra layer of security.",
                "xss" => "Additional information: Prevent XSS attacks by implementing Content Security Policy (CSP) headers and validating/sanitizing user input.",
                "shoulder-surfing" => "Additional information: Use privacy filters on screens and be aware of your surroundings in high-security environments.",
                "hashing-vs-encryption" => "Additional information: Hashing is used for verifying data integrity and storing passwords, while encryption secures data in transit or at rest.",
                "information-security-vs-assurance" => "Additional information: Information security focuses on protecting data, while information assurance ensures data is accessible when needed.",
                "https-vs-ssl" => "Additional information: SSL has been deprecated in favor of TLS, which provides similar functionality with improved security.",
                "system-hardening" => "Additional information: Create detailed hardening checklists for different systems and ensure they're followed during setup and updates.",
                "spear-phishing" => "Additional information: Defend against spear-phishing with email filtering and educating employees to verify request authenticity.",
                "perfect-forward-secrecy" => "Additional information: PFS ensures that session keys are not compromised even if long-term keys are compromised, enhancing security for sensitive communications.",
                "mitm-prevention" => "Additional information: Prevent man-in-the-middle attacks using VPNs, HTTPS, and certificate pinning.",
                "ransomware-detailed" => "Additional information: Regularly test backup restoration and consider air-gapped backups to protect against ransomware attacks.",
                "public-key-infrastructure" => "Additional information: Manage PKI with proper certificate lifecycle management and use monitoring tools to track expiration.",
                "spoofing" => "Additional information: Implement SPF, DKIM, and DMARC records to prevent email spoofing attacks.",
                "server-hacking-steps" => "Additional information: Regularly review server logs and use automated analysis tools to detect potential intrusion attempts.",
                "sniffing-tools" => "Additional information: Protect against network sniffing with encryption and network segmentation.",
                "sql-injection" => "Additional information: Prevent SQL injection by using parameterized queries, input validation, and limiting database user privileges.",
                "ddos" => "Additional information: Implement rate limiting and use cloud-based DDoS protection services to absorb large attack volumes.",
                "arp-poisoning-prevention" => "Additional information: Use Dynamic ARP Inspection (DAI) on larger networks to validate ARP packets.",
                "proxy-firewall" => "Additional information: Configure proxy servers to filter traffic and enforce organizational security policies.",
                "ssl-encryption" => "Additional information: Regularly update SSL/TLS certificates and implement certificate monitoring.",
                "penetration-testing" => "Additional information: Document findings from penetration tests and develop detailed remediation plans.",
                "public-wifi-risks" => "Additional information: Avoid conducting sensitive transactions on public Wi-Fi even with a VPN. Use mobile data instead.",
                "diffie-hellman-vs-rsa" => "Additional information: Diffie-Hellman is used for key exchange, while RSA can be used for encryption and digital signatures.",
                "asymmetric-encryption-examples" => "Additional information: ECC offers similar security to RSA with smaller key sizes, making it more efficient for many applications.",
                "vulnerability-vs-exploit" => "Additional information: Vulnerabilities are weaknesses in systems, while exploits are methods used to take advantage of these weaknesses.",
                "risk-vulnerability-threat" => "Additional information: Conduct regular risk assessments to identify threats and vulnerabilities relevant to your organization.",
                "phishing-prevention" => "Additional information: Implement DMARC email authentication and train employees to verify email authenticity.",
                "forward-secrecy" => "Additional information: Forward secrecy protects past communications even if long-term keys are compromised.",
                "joke" => "Why did the hacker stay out of trouble? Because they always had strong passwords! 🔐😆",
                _ => "Additional information: Would you like more details on a specific cybersecurity topic?"
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
                this.PlaySound("C:\\Users\\lab_services_student\\Desktop\\New folder\\PROGPart1POE\\ProgAssignment\\ProgAssignment\\Security Bot.wav");

                // Display ASCII art
                DisplayAsciiArt();

                // Get user name
                Console.Write("Enter your name: ");
                userName = Console.ReadLine();

                // Update greeting response with user's name
                var greeting = responses.FirstOrDefault(r => r is GreetingResponse) as GreetingResponse;
                if (greeting != null)
                {
                    greeting.UserName = userName;
                }

                // Main interaction loop
                while (true)
                {
                    DisplayChatWindow();

                    Console.Write("\nAsk me something (or type 'exit' to quit): ");
                    string input = Console.ReadLine();

                    // Trigger event
                    OnUserInputReceived?.Invoke(input);

                    if (input.ToLower() == "exit") break;

                    // Check if user wants to start the quiz
                    if (input.Trim().ToLower() == "quiz me")
                    {
                        CybersecurityQuiz quiz = new CybersecurityQuiz();
                        quiz.StartQuiz();
                        continue;
                    }

                    ProcessUserInput(input);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
        }

        private void PlaySound(string filePath)
        {
            try
            {
                using (var waveOutEvent = new WaveOutEvent())
                using (var audioFile = new AudioFileReader(filePath))
                {
                    waveOutEvent.Init(audioFile);
                    waveOutEvent.Play();
                    while (waveOutEvent.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }

        private void ProcessUserInput(string input)
        {
            try
            {
                // Normalize input: trim, lowercase, remove punctuation
                string normalizedInput = input.Trim().ToLower();
                normalizedInput = new string(normalizedInput.Where(c => char.IsLetterOrDigit(c) || c == ' ').ToArray());

                // Add user input to chat history
                chatHistory.Add($"You: {input}");

                // Check if we need to remember something
                StoreUserMemory(input);

                // Check for sentiment
                string sentiment = DetectSentiment(normalizedInput);

                // Check if user is confused
                if (IsUserConfused(normalizedInput))
                {
                    ProvideAdditionalInformation(lastTopic);
                    return;
                }

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

                // Check for exact Trigger match
                var matchedResponse = responses.FirstOrDefault(r =>
                    r.Trigger.Equals(normalizedInput, StringComparison.OrdinalIgnoreCase));

                // Check for partial Trigger match or Trigger contains input
                var keywordMatch = responses.FirstOrDefault(r =>
                    r.Trigger.Split('-').Any(keyword => normalizedInput.Contains(keyword)) ||
                    r.Trigger.Contains(normalizedInput));

                // Check for Keywords in GeneralResponses
                var generalKeywordMatch = responses.OfType<GeneralResponse>().FirstOrDefault(gr =>
                    gr.Keywords.Any(kw => normalizedInput.Contains(kw.ToLower())));

                if (matchedResponse != null)
                {
                    lastTopic = matchedResponse.Trigger;
                    ProcessMatchedResponse(matchedResponse, sentiment);
                }
                else if (keywordMatch != null)
                {
                    lastTopic = keywordMatch.Trigger;
                    ProcessMatchedResponse(keywordMatch, sentiment);
                }
                else if (generalKeywordMatch != null)
                {
                    lastTopic = generalKeywordMatch.Trigger;
                    ProcessGeneralResponseMatch(generalKeywordMatch, sentiment);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    chatHistory.Add("Bot: I didn't understand. Try asking about passwords, phishing, securing your home network, protecting your smartphone, or family online safety. Type 'help' for options.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error processing input: {ex.Message}");
                Console.ResetColor();
            }
        }
        
        private bool HasKeywordBeenCalled(string keyword)
        {
            return chatHistory.Any(message => message.StartsWith("Bot: ") && message.ToLower().Contains(keyword.ToLower()));
        }
        private bool IsUserConfused(string input)
        {
            return input.Contains("confused") || input.Contains("confusing") || input.Contains("don't understand") || input.Contains("explain more");
        }

        private void ProvideAdditionalInformation(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                chatHistory.Add("Bot: I'm not sure which topic you need more information about. Could you please clarify?");
                Console.ResetColor();
                return;
            }

            var securityResponse = responses.FirstOrDefault(r => r is SecurityResponse && r.Trigger == topic) as SecurityResponse;
            if (securityResponse != null && !string.IsNullOrEmpty(securityResponse.ExtendedResponse))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                chatHistory.Add($"Bot: Here's more information about {topic}: {securityResponse.ExtendedResponse}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                chatHistory.Add("Bot: I have more information on this topic. Would you like me to provide it?");
                Console.ResetColor();
            }
            DisplayTypingEffect();
        }

        private void ProcessMatchedResponse(BotResponse response, string sentiment)
        {
            bool keywordRepeated = HasKeywordBeenCalled(response.Trigger);

            string botResponse = response.GetResponse();
            if (sentiment != null)
            {
                botResponse = AdjustResponseBasedOnSentiment(botResponse, sentiment);
            }

            if (keywordRepeated)
            {
                botResponse = $"Here is a different perspective, {botResponse}";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            chatHistory.Add($"Bot: {botResponse}");
            Console.ResetColor();
            DisplayTypingEffect();
        }

        private void ProcessGeneralResponseMatch(GeneralResponse response, string sentiment)
        {
            bool keywordRepeated = response.Keywords.Any(kw => HasKeywordBeenCalled(kw));

            string botResponse = response.GetResponse();
            if (sentiment != null)
            {
                botResponse = AdjustResponseBasedOnSentiment(botResponse, sentiment);
            }

            if (keywordRepeated)
            {
                botResponse = $"As I mentioned before, {botResponse}";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            chatHistory.Add($"Bot: {botResponse}");
            Console.ResetColor();
            DisplayTypingEffect();
        }

        private bool HasKeywordBeenUsed(string keyword)
        {
            return chatHistory.Any(message => message.StartsWith("Bot: ") && message.ToLower().Contains(keyword.ToLower()));
        }

        private void StoreUserMemory(string input)
        {
            try
            {
                // Check for user information to remember
                if (input.Contains("interested in"))
                {
                    string[] parts = input.Split(new[] { "interested in" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 1)
                    {
                        string interest = parts[1].Trim();
                        userMemory["interest"] = interest;
                        chatHistory.Add($"Bot: Great! I'll remember that you're interested in {interest}. It's a crucial part of staying safe online.");
                    }
                }
                else if (input.Contains("my favorite topic is"))
                {
                    string[] parts = input.Split(new[] { "my favorite topic is" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 1)
                    {
                        string topic = parts[1].Trim();
                        userMemory["favorite_topic"] = topic;
                        chatHistory.Add($"Bot: Awesome! {topic} is an important cybersecurity subject.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error storing user memory: {ex.Message}");
                Console.ResetColor();
            }
        }

        private string DetectSentiment(string input)
        {
            // Simple sentiment detection
            if (input.Contains("worried") || input.Contains("concerned") || input.Contains("afraid"))
            {
                return "worried";
            }
            else if (input.Contains("curious") || input.Contains("interested") || input.Contains("like to learn"))
            {
                return "curious";
            }
            else if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("don't understand"))
            {
                return "frustrated";
            }
            else
            {
                return null;
            }
        }

        private string AdjustResponseBasedOnSentiment(string originalResponse, string sentiment)
        {
            try
            {
                switch (sentiment)
                {
                    case "worried":
                        return $"I understand you're worried. {originalResponse} Remember, taking small steps can make a big difference in your online security.";
                    case "curious":
                        return $"I'm glad you're curious! {originalResponse} Would you like more details on any specific aspect?";
                    case "frustrated":
                        return $"I'm sorry if this seems frustrating. {originalResponse} Let's break it down together, and I'll help you understand it better.";
                    default:
                        return originalResponse;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error adjusting response: {ex.Message}");
                Console.ResetColor();
                return originalResponse;
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
            foreach (var message in chatHistory.TakeLast(10))
            {
                if (message.StartsWith("You: "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // User message color
                }
                else if (message.StartsWith("Bot: "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Bot message color
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray; // Default color
                }

                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        private void DisplayTypingEffect()
        {
            Console.Write("\nBot is thinking...");
            Thread.Sleep(1000);
            Console.Write("\r{0," + Console.WindowWidth + "}", ""); // Clear line
        }

        private void DisplayAsciiArt()
        {
            string asciiArt = @"

   _-_   _-   -_   _-_     _-_     _-_     _-_    _---_   __-__
  / __|  \ \ / /  | _ )   | __|   | _ \   | _ )   / _ \  |_   _|
 | (__    \ V /   | _ \   | _|    |   /   | _ \  | (_) |   | |  
  \___|   _|_|_   |___/   |___|   |_|_\   |___/   \___/   _|_|_ 
_|""""""""""|_| """""" |_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|
""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'
";
            Console.WriteLine(asciiArt);
            Console.WriteLine();
        }
    }
}