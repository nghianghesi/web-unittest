namespace UF.WebMockUtil;
public class MockSetup : Attribute{
    public string TestCaseName {get;private set;}
    public MockSetup(string testCaseName) {
        this.TestCaseName = testCaseName;
    }
}