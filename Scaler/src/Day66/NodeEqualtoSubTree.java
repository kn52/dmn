package Day66;

public class NodeEqualtoSubTree {
	int ans;
	
	public static void main(String[] args) {
		
	}
	
    public int averageOfSubtree(TreeNode root) {
        ans=0;
        traverse(root);
        return ans;
    }
   
    private int[] traverse(TreeNode root)
    {
        if(root==null)
            return new int[]{0,0};
        int[] left = traverse(root.left);
        int[] right = traverse(root.right);
        int sum = left[0]+right[0]+root.val;
        int cnt = left[1]+right[1]+1;
        if(sum/cnt==root.val){
            ans++;
        }
        return new int[]{sum,cnt};
    }
    
   
}
